using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Hubs
{
    public interface ICasherClient
    {
        Task seatStatusReceived(int status, string trip, string seat);
    }
}
