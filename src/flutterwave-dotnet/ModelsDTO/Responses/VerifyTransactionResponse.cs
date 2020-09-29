namespace Flutterwave.Net
{
    public class VerifyTransactionResponse : TransactionResponse<Transaction>
    {
        public override Transaction Data { get; set; }
    }
}
