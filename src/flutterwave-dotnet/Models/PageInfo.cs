using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class PageInfo
    {
        public int Total { get; set; }
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
