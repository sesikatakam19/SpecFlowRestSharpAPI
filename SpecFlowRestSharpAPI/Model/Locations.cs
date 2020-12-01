using Newtonsoft.Json;


namespace SpecFlowRestSharpAPI.Model
{
    public class Locations
    {
        [JsonProperty("latitude")]
        public double latitude { get; set; }
        [JsonProperty("longitude")]
        public double longtitude { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }

    }
}
