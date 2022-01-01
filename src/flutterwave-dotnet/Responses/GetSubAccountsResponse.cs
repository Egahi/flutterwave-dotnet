using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetSubAccountsResponse : Response<List<SubAccount>>
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}