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

            var command = args[3];
            switch (command)
            {
                case "venues-list":
                    await PrintVenuesList(configuration);
                    break;
                case "venue-info":
                    await PrintVenueInfo(configuration, args[4]);
                    break;
                case "venue-radio-maps":
                    await PrintVenueRadioMaps(configuration, args[4]);
                    break;
                case "venue-radio-map-info":
                    await PrintVenueRadioMaps(configuration, args[4], args[5]);
                    break;
                default:
                    System.Console.WriteLine($"Unknown operation {command}");
                    break;
            }
        }

        private static async Task PrintVenuesList(RuckusApiConfiguration configuration)
        {
            var api = new RuckusApi(configuration);
            var venues = await api.GetVenues();
            System.Console.WriteLine("List of all venues");
            foreach (var venue in venues)
            {
                System.Console.WriteLine($"Id: {venue.Id}, Name: {venue.Name}");
            }
        }

        private static async Task PrintVenueInfo(RuckusApiConfiguration configuration, string venueId)
        {
            var api = new RuckusApi(configuration);
            var venue = await api.GetVenue(venueId);
            System.Console.WriteLine($"Get information about venue {venueId}");
            System.Console.WriteLine($"Name: {venue.Name}");
            System.Console.WriteLine($"Image: {venue.ExteriorImage}");
            System.Console.WriteLine($"Address: {venue.StreetAddress}");
            System.Console.WriteLine($"Locality: {venue.Locality}");
            System.Console.WriteLine($"Region: {venue.Region}");
            System.Console.WriteLine($"ZIP: {venue.PostalCode}");
            System.Console.WriteLine($"Country: {venue.CountryName}");
            if (venue.Coordinates != null)
            {
                System.Console.WriteLine($"Coordinates (lon): {venue.Coordinates[0]},{venue.Coordinates[1]}");
            }

            System.Console.WriteLine($"Time Zone: {venue.TimeZoneId}");
        }

        private static async Task PrintVenueRadioMaps(RuckusApiConfiguration configuration, string venueId)
        {
            var api = new RuckusApi(configuration);
            var venueRadioMaps = await api.GetVenueRadioMaps(venueId);
            System.Console.WriteLine($"List radio maps for venue {venueId}");
            foreach (var venueRadioMap in venueRadioMaps)
            {
                System.Console.WriteLine($"Name: {venueRadioMap.Name}, Is Production?: {venueRadioMap.Production}");
            }
        }

        private static async Task PrintVenueRadioMaps(RuckusApiConfiguration configuration, string venueId, string name)
        {
            var api = new RuckusApi(configuration);
            var venueRadioMap = await api.GetRadioMap(venueId, name);
            System.Console.WriteLine($"Show radio map for venue {venueId} with name {name}");
            
        }
    }
}
