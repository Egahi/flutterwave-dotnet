using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class Customizations
    {
        public Customizations(string title,
                              string description,
                              string logo)
        {
            Title = title;
            Description = description;
            Logo = logo;
        }

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
