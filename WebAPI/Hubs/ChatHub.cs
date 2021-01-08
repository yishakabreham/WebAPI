using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace WebAPI.Hubs
{
    public class ChatHub:Hub
    {
        public async Task Send(string name, string message)
        {
            Console.WriteLine("Received message=> " + name + " : " + message);
            await Clients.Others.SendAsync("broadcastMessage", name, message);
        }

        public async Task seatStatusUpdated(int status, string trip, string seat)
        {
            switch (status)
            {
                case 1:
                    await SeatsOnProccess.addOnProcess(trip, seat);
                    break;
                case -1:
                case 2:
                    await SeatsOnProccess.removeOnProcess(trip, new List<string> { seat });
                    break;
                default:
                    break;
            }
            Console.WriteLine("Change State to => " + status + " : " + trip + " = " + seat);
            await Clients.Others.SendAsync("seatStatusReceived", status, trip, seat );
        }

        public async Task updatedMe(string trip)
        {
            Console.WriteLine("Update Me about => " + trip);
            var updates = await SeatsOnProccess.getOnProcessSeats(trip);
            await Clients.Caller.SendAsync("seatStatusReceived", 1, trip, updates.Any() ? String.Join('%', updates) : null);
        }
    }
}
