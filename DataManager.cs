namespace Ummmmbraco
{
    public class Root
    {
        public List<Station> Stations { get; set; } 
    }

    public class Station
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public Coordinates coordinates { get; set; }
        public double rating { get; set; }
        public bool paid { get; set; }
    }
    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class DataManager
    {
        public static async Task<Root> GetStationsAsync()
        {
            HttpClient client = new HttpClient();
            Root? data = await client.GetFromJsonAsync<Root>("http://gaddr.co/ios/stations");
            return data;
        }
    }
}
