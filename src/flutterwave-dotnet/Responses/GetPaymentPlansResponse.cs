using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetPaymentPlansResponse : Response<List<PaymentPlan>>
    {
        public Meta Meta { get; set; }
    }
}