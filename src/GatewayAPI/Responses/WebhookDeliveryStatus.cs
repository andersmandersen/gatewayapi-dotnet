using GatewayAPI.Interfaces;
using Newtonsoft.Json;

namespace GatewayAPI.Responses
{
    public class WebhookDeliveryStatus : IWebhookResponse
    {
        public int id { get; set; }
        public long msisdn { get; set; }
        public double time { get; set; }
        public string status { get; set; }
        public string error { get; set; }
        public string code { get; set; }
        public string userref { get; set; }
        public string country_code { get; set; }
        public int country_prefix { get; set; }


        /// <summary>
        /// Parse response from GatewayAPI into Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static WebhookDeliveryStatus ParseResponse(string payload)
        {
            return JsonConvert.DeserializeObject<WebhookDeliveryStatus>(payload);
        }
    }
}
