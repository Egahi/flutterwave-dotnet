using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public abstract class Response<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
