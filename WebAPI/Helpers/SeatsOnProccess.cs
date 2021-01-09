using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Helpers
{
    public static class SeatsOnProccess
    {
        static Dictionary<string, List<string>> processZip = new Dictionary<string, List<string>>();
        static List<ConnectonTripSeats> connectionSeats = new List<ConnectonTripSeats>();

        public static async Task<List<string>> getOnProcessSeats(string trip) => await Task.Run(() => processZip.GetValueOrDefault(trip));

        public static async Task removeOnProcess(string trip, IEnumerable<string> seats)
        {
            var tpValue = processZip.GetValueOrDefault(trip);
            if(tpValue != null)
            {
                await Task.Run(() => tpValue.RemoveAll(s => seats.Contains(s)));
                if (!tpValue.Any())
                {
                    await Task.Run(() => processZip.Remove(trip));
                }
            }
        }

        public static async Task addOnProcess(string trip, string seat) =>
                            await (processZip.ContainsKey(trip) ?
                            Task.Run(() => processZip.GetValueOrDefault(trip).Add(seat)) :
                            Task.Run(() => processZip.Add(trip, new List<string> { seat })));

        public static async Task removeConnSeats(string connection, IEnumerable<string> seats)
        {
            var conSeat = connectionSeats.FirstOrDefault(c => c.connectionId == connection);
            if (conSeat != null)
            {
                await Task.Run(() => conSeat.seats.RemoveAll(s => seats.Contains(s)));
                if (!conSeat.seats.Any())
                {
                    await Task.Run(() => connectionSeats.Remove(conSeat));
                }
            }
        }
        
        public static async Task removeAllConnSeats(string connection) => await Task.Run(() => connectionSeats.RemoveAll(c => c.connectionId == connection));

        public static async Task addConnSeats(string connection, string trip, string seat) =>
                            await (connectionSeats.Any(c => c.connectionId == connection && c.trip == trip) ?
                            Task.Run(() => connectionSeats.FirstOrDefault(c => c.connectionId == connection).seats.Add(seat)) :
                            Task.Run(() => connectionSeats.Add(new ConnectonTripSeats { connectionId = connection, trip = trip , seats = new List<string> { seat } })));

        public static async Task<ConnectonTripSeats> getConnSeats(string connection) => await Task.Run(() => connectionSeats.FirstOrDefault(c => c.connectionId == connection));
    }

    public class ConnectonTripSeats
    {
        public string connectionId { get; set; }
        public string trip { get; set; }
        public List<string> seats { get; set; }
    }
}
