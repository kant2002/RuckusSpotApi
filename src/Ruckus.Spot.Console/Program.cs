using Ruckus.Spot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruckus.Spot.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            var task = program.Process(args);
            task.Wait();
        }

        public async Task Process(string[] args)
        {
            var configuration = new RuckusApiConfiguration();
            configuration.ServerUrl = args[0];
            var result = await AuthHelper.GetApiToken(configuration, args[1], args[2]);
            configuration.ApiToken = result.ApiKey;

            var api = new RuckusApi(configuration);
            var venues = await api.GetVenues();
            System.Console.WriteLine("List of all venues");
            foreach (var venue in venues)
            {
                System.Console.WriteLine($"Id: {venue.Id}, Name: {venue.Name}");
            }
        }
    }
}
