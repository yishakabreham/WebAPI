using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace WebAPI.Hubs
{
    public class ChatHub : Hub<ICasherClient>
    {
        public async Task Send(string name, string message)
        {
            Console.WriteLine("Received message=> " + name + " : " + message);
            //await Clients.Others.SendAsync("broadcastMessage", name, message);
        }

        public async Task SeatStatusUpdated(int status, string trip, string seat)
        {
            switch (status)
            {
                case 1:
                    await SeatsOnProccess.addOnProcess(trip, seat);
                    await SeatsOnProccess.addConnSeats(Context.ConnectionId, trip, seat);
                    break;
                case -1:
                case 2:                    
                    await (!seat.Contains("%") ? 
                        SeatsOnProccess.removeOnProcess(trip, new string[] { seat }) :
                        SeatsOnProccess.removeOnProcess(trip, seat.Split("%")));
                    await (!seat.Contains("%") ?
                        SeatsOnProccess.removeConnSeats(Context.ConnectionId, new string[] { seat }) :
                        SeatsOnProccess.removeConnSeats(Context.ConnectionId, seat.Split("%")));
                    break;
                default:
                    break;
            }

            Console.WriteLine("Change State to => " + status + " : " + trip + " = " + seat);
            await Clients.Others.seatStatusReceived(status, trip, seat );
        }

        public async Task UpdatedMe(string trip)
        {
            Console.WriteLine("Update Me about => " + trip);
            var updates = await SeatsOnProccess.getOnProcessSeats(trip);
            await Clients.Caller.seatStatusReceived(1, trip, updates.Any() ? String.Join('%', updates) : null);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var conSeats = SeatsOnProccess.getConnSeats(Context.ConnectionId);
            conSeats.Wait();
            if(conSeats.Result != null)
            {
                SeatStatusUpdated(-1, conSeats.Result.trip, String.Join("%", conSeats.Result.seats)).Wait();
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
