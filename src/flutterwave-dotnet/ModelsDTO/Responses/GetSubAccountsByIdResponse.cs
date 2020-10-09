using Newtonsoft.Json;

namespace Flutterwave.Net
{
    public class GetSubAccountsByIdResponse : Response<GetSubAccounts>
    {
        [JsonProperty("meta")]
        public Meta meta { get; set; }
    }
}