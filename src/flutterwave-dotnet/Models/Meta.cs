using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class Meta
    {
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
