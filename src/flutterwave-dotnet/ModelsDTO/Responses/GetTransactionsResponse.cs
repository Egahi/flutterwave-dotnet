using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetTransactionsResponse : TransactionResponse<List<DataItem>>
    {
        public Meta Meta { get; set; }
        public override List<DataItem> Data { get; set; }
    }
}
