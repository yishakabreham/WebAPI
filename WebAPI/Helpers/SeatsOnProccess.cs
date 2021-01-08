using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public static class SeatsOnProccess
    {
        static Dictionary<string, List<string>> processZip = new Dictionary<string, List<string>>();

        public static async Task<List<string>> getOnProcessSeats(string trip) => await Task.Run(() => processZip.GetValueOrDefault(trip));

        public static async Task removeOnProcess(string trip, List<string> seats) => await Task.Run(() => processZip.GetValueOrDefault(trip)?.RemoveAll(s => seats.Contains(s)));

        public static async Task addOnProcess(string trip, string seat) =>
                            await (processZip.ContainsKey(trip) ?
                            Task.Run(() => processZip.GetValueOrDefault(trip).Add(seat)) :
                            Task.Run(() => processZip.Add(trip, new List<string> { seat })));        
    }
}
