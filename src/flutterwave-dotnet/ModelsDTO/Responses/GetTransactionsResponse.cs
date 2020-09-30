using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetTransactionsResponse : TransactionResponse<List<Transaction>>
    {
        public Meta Meta { get; set; }
    }
}
