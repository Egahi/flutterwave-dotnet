using Flutterwave.Net;
using System;
using System.Configuration;

namespace flutterwave_dotnet_test
{
    class Program
    {
        private FlutterwaveApi flutterwaveApi { get; }

        public Program()
        {
            // Get your rave secret key from your config file
            var raveSecretKey = ConfigurationManager.AppSettings.Get("RaveSecretKey");
            flutterwaveApi = new FlutterwaveApi(raveSecretKey);
        }

        public static void Main(string[] args)
        {
            var driver = new Program();
            driver.GetTransactions();
        }

        private void GetTransactions()
        {
            var transactions = flutterwaveApi.Transactions.GetTransactions();

            Console.WriteLine("Status: " + transactions.Status);
            Console.WriteLine("Message: " + transactions.Message);

            if (transactions.Status == "success")
            {
                Console.WriteLine("Current Page: " + transactions.Meta.PageInfo.CurrentPage);
                Console.WriteLine("Total Pages: " + transactions.Meta.PageInfo.TotalPages);
                Console.WriteLine("Total Transactions: " + transactions.Data.Count);
                Console.WriteLine();

                for (int i = 0; i < transactions.Data.Count; i++)
                {
                    Console.WriteLine("S/N: " + (i + 1));
                    Console.WriteLine("Id: " + transactions.Data[i].Id);
                    Console.WriteLine("Tx_Ref: " + transactions.Data[i].TxRef);
                    Console.WriteLine("Amount: " + transactions.Data[i].Amount);
                    Console.WriteLine("Status: " + transactions.Data[i].Status);
                }
            }
        }
    }
}
