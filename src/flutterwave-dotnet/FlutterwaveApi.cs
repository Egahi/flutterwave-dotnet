using Flutterwave.Net.Utilities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Flutterwave.Net
{
    public class FlutterwaveApi : IFlutterwaveApi
    {
        private HttpClient HttpClient { get; }
        public ITransactions Transactions { get; }

        public FlutterwaveApi(string secretKey)
        {
            HttpClient = new HttpClient { BaseAddress = new Uri(AppConstants.FLUTTERWAVE_API_BASE_URL) };
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Transactions = new Transactions(this);
        }

        /// <summary>
        /// Make Get requests to Flutterwave API
        /// </summary>
        /// <typeparam name="TR">Response Data Type</typeparam>
        /// <param name="relativeUrl">endpoint</param>
        /// <returns></returns>
        internal TR Get<TR>(string relativeUrl)
        {
            var responseStr = HttpClient.GetAsync(relativeUrl)
                                        .Result
                                        .Content
                                        .ReadAsStringAsync()
                                        .Result;

            var responseData = JsonConvert.DeserializeObject<TR>(responseStr);

            return responseData;
        }

        /// <summary>
        /// Make Post requests to Flutterwave to API
        /// </summary>
        /// <typeparam name="TR">Response Data Type</typeparam>
        /// <param name="relativeUrl">endpoint</param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal TR Post<TR>(string relativeUrl, object data)
        {
            var jsonData = new StringContent(JsonConvert.SerializeObject(data),
                                             Encoding.UTF8,
                                             "application/json");

            var responseStr = HttpClient.PostAsync(relativeUrl, jsonData)
                                        .Result
                                        .Content
                                        .ReadAsStringAsync()
                                        .Result;

            var responseData = JsonConvert.DeserializeObject<TR>(responseStr);

            return responseData;
        }
    }
}
