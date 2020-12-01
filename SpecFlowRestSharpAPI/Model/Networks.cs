using Newtonsoft.Json;


namespace SpecFlowRestSharpAPI.Model
{
    public class Networks
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("href")]
        public string href { get; set; }
        [JsonProperty("company")]
        public object company { get; set; }
        [JsonProperty("location")]
        public Locations location {get; set;}

    }
}
