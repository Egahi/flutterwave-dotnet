using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetTransactionsResponse : TransactionResponse<List<Transaction>>
    {
        public Meta Meta { get; set; }
        public override List<Transaction> Data { get; set; }
    }
}
