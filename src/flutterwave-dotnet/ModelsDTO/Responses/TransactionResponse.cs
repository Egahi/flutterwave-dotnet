namespace Flutterwave.Net
{
    public abstract class TransactionResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public virtual T Data { get; set; }
    }
}
