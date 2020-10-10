using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetTransactionsResponse : Response<List<Transaction>>
    {
        public Meta Meta { get; set; }
    }
}
