namespace Flutterwave.Net
{
    public class InitiatePaymentResponse : TransactionResponse<HostedLink>
    {
        public override HostedLink Data { get; set; }
    }
}
