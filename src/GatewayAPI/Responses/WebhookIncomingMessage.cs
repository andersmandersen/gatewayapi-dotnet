using GatewayAPI.Interfaces;
using Newtonsoft.Json;

namespace GatewayAPI.Responses
{
    public class WebhookIncomingMessage : IWebhookResponse
    {
        public int id { get; set; }
        public long msisdn { get; set; }
        public int receiver{ get; set; }
        public string message { get; set; }
        public int senttime { get; set; }
        public string webhook_label { get; set; }
        public string sender { get; set; }
        public int mcc { get; set; }
        public int mnc { get; set; }
        public int validity_period { get; set; }
        public string encoding { get; set; }
        public string udh { get; set; }
        public string payload { get; set; }
        public string country_code { get; set; }
        public int? country_prefix { get; set; }

        /// <summary>
        /// Parse response from GatewayAPI into Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static WebhookIncomingMessage ParseResponse(string payload)
        {
            return JsonConvert.DeserializeObject<WebhookIncomingMessage>(payload);
        }
    }
}
