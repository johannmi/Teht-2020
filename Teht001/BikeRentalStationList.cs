using System.Collections.Generic;
public class BikeRentalStationList
{
    public List<stations> stations { get; set; }
}

public class stations
{
    public int id { get; set; }
    public string name { get; set; }
    public float x { get; set; }
    public float y { get; set; }
    public int bikesAvailable { get; set; }
    public int spacesAvailable { get; set; }
    public bool allowDropoff { get; set; }
    public bool isFloatingBike { get; set; }
    public bool isCarStation { get; set; }
    public string state { get; set; }
    public List<string> networks { get; set; }
    public bool realTimeData { get; set; }

}
