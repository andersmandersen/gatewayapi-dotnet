using Newtonsoft.Json;
using RestSharp;

namespace GatewayAPI.Responses
{
    public class AccountBalance
    {
        public int id { get; set; }
        public double credit { get; set; }
        public string currency { get; set; }

        /// <summary>
        /// Parse response from GatewayAPI into Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static AccountBalance ParseResponse(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<AccountBalance>(response.Content);
        }
    }
}
