using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Responses
{
    public class Prices
    {
        public List<PricesPremium> premium { get; set; }
        public List<PricesStandard> standard { get; set; }

        /// <summary>
        /// Parse response from GatewayAPI into Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Prices ParseResponse(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<Prices>(response.Content);
        }
    }

    public class PricesPremium
    {
        public string country { get; set; }
        public string country_name { get; set; }
        public double dkk { get; set; }
        public double eur { get; set; }
        public int? prefix { get; set; }
    }

    public class PricesStandard
    {
        public string country { get; set; }
        public string country_name { get; set; }
        public double dkk { get; set; }
        public double eur { get; set; }
        public int? prefix { get; set; }
    }
}
