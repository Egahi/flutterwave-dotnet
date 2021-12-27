namespace Flutterwave.Net
{
  public class Charge
  {
    private FlutterwaveApi _flutterwaveApi { get; }

    public Charge(FlutterwaveApi flutterwaveApi)
    {
      _flutterwaveApi = flutterwaveApi;
    }

    public void ChargeCard(decimal amount,
                           Currency currency = Currency.NigerianNaira
      )
    {

    }
  }
}
