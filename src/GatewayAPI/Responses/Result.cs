using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace GatewayAPI.Responses
{
    public class Result
    {
        public List<long> Ids { get; set; }

        /// <summary>
        /// Parse response from GatewayAPI into Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Result ParseResponse(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<Result>(response.Content);
        }
    }
}