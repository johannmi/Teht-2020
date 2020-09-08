using System.Threading.Tasks;
using System.IO;
using System;
using System.Linq;

public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher
{
    public Task<int> GetBikeCountInStation(string stationName)
    {
        if (stationName.Any(char.IsDigit))
        {
            throw new System.ArgumentException();
        }

        int found = 0;
        string textFile = "bikedata.txt";
        string[] lines = File.ReadAllLines(textFile);
  
        foreach (string line in lines) {
            if(line.Contains(stationName)) {
                found = line.IndexOf(": ");
                int bikesAvailable = Int32.Parse(line.Substring(found + 2));
                return Task.FromResult(bikesAvailable);
            }
        }

        throw new NotFoundException();
    }
}
