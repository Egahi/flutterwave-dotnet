using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetTransactionsResponse : Response<List<Transaction>>
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
