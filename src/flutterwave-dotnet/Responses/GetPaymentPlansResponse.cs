using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetPaymentPlansResponse : Response<List<PaymentPlan>>
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}