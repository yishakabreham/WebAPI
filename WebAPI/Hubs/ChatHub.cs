using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Hubs
{
    public class ChatHub:Hub
    {
        public async Task Send(string name, string message)
        {
            Console.WriteLine("Received message=> " + name + " : " + message);
            await Clients.Others.SendAsync("broadcastMessage", name, message);
        }

        public async Task seatStatusUpdated(int status, string seat)
        {
            Console.WriteLine("Received message=> " + status + " : " + seat);
            await Clients.Others.SendAsync("seatStatusReceived", status, seat);
        }
    }
}
