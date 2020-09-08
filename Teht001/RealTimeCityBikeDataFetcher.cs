using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Linq;
public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    static readonly HttpClient client = new HttpClient();
    public async Task<int> GetBikeCountInStation(string stationName) {

        if (stationName.Any(char.IsDigit))
        {
            throw new System.ArgumentException();
        }

        try	
        {
            HttpResponseMessage response = 
                await client.GetAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            BikeRentalStationList bikes = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);

            foreach (stations station in bikes.stations) {
                if(stationName.Equals(station.name)) {
                    return station.bikesAvailable;
                }
            }

            throw new NotFoundException();
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");	
            Console.WriteLine("Message :{0} ",e.Message);
            return 0;
        }
    }
}