using Newtonsoft.Json;

namespace ContentToolLibrary.Models
{
    public class SettingsModel
    {
        [JsonProperty("CurrentContent")]
        public string? CurrentContent { get; set; }
        
        [JsonProperty("NewImages")]
        public string? NewImages { get; set; }
        
        [JsonProperty("OutputDirectory")]
        public string? OutputDirectory { get; set; }
    }
}