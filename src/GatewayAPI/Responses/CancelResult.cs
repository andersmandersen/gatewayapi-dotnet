using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Responses
{
    public class CancelResult
    {
        public long MessageId { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Parse response from GatewayAPI into Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static CancelResult ParseResponse(int messageId, HttpStatusCode status)
        {
            return new CancelResult
            {
                MessageId = messageId,
                Status = ((int)status != 204 ? "failed" : "success")
            };            
        }
    }    
}
