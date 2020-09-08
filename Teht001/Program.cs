using System;
using System.Threading.Tasks;

namespace Teht001
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Aseman nimi: ");
            string stationName = Console.ReadLine();
            int bikesAvailable;

            // ONLINE
            if (args[0].Equals("realtime")){
                RealTimeCityBikeDataFetcher data = new RealTimeCityBikeDataFetcher();

                try {
                    bikesAvailable = await data.GetBikeCountInStation(stationName);
                    Console.WriteLine("Pyöriä paikassa " + stationName + " on vapaana " + bikesAvailable);
                } 
                catch(ArgumentException m) {
                    Console.WriteLine("\nInvalid argument: " + m);
                }
                catch(NotFoundException m) {
                    Console.WriteLine("\nNot found: " + m);
                }
            } 
            // OFFLINE
            else if (args[0].Equals("offline")) {
                try {
                    OfflineCityBikeDataFetcher data = new OfflineCityBikeDataFetcher();
                    bikesAvailable = await data.GetBikeCountInStation(stationName);
                    Console.WriteLine("Pyöriä paikassa " + stationName + " on vapaana " + bikesAvailable);
                } 
                catch(ArgumentException m) {
                    Console.WriteLine("\nInvalid argument: " + m);
                }
                catch(NotFoundException m) {
                    Console.WriteLine("\nNot found: " + m);
                }

            } else {
                Console.WriteLine("Exiting program...");
            }
        }
    }
}
