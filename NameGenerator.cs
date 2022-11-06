namespace Ummmmbraco
{
    public class Names
    {
        public Success success { get; set; }
        public Contents contents { get; set; }
        public string copyright { get; set; }
    }
    public class Contents
    {
        public string category { get; set; }
        public object variation { get; set; }
        public List<string> names { get; set; }
    }
    public class Success
    {
        public object total { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
    }
    public class NameGenerator
    {
        public static async Task<Names> GetNamesAsync()
        {
            HttpClient client = new HttpClient();
            Names? data = await client.GetFromJsonAsync<Names>("https://api.fungenerators.com/name/generate?category=car&limit=1");
            return data;
        }

    }
}