using System;
using RestSharp;
using GatewayAPI.Responses;
using System.Collections.Generic;
using GatewayAPI.Entities;
using GatewayAPI.Exceptions;
using Newtonsoft.Json;

namespace GatewayAPI
{
    public class GatewayAPIHandler
    {        
        private RestClient client = new RestSharp.RestClient("https://gatewayapi.com/rest/");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey"></param>
        public GatewayAPIHandler(string apiKey, string token = "")
        {
            this.client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(apiKey, "");            
        }

        /// <summary>
        /// Send a single message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Result SendMessage(SMSMessage message)
        {
            IRestResponse response = this.Request(RestSharp.Method.POST, "mtsms", message.ToJson());
            return Result.ParseResponse(response);
        }

        /// <summary>
        /// Send multiple messages
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public Result SendMessages(List<SMSMessage> messages)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new JsonResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            string body =  Newtonsoft.Json.JsonConvert.SerializeObject(this, settings);

            IRestResponse response = this.Request(RestSharp.Method.POST, "mtsms", body);
            return Result.ParseResponse(response);
        }

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns></returns>
        public AccountBalance GetAccountBalance()
        {
            IRestResponse response = this.Request(RestSharp.Method.GET, "me");
            return AccountBalance.ParseResponse(response);
        }

        /// <summary>
        /// Get a json list of prices from API. The endpoint is public, and can always be viewed.
        /// </summary>
        /// <returns></returns>
        public Prices GetPricesAsJson()
        {
            this.client.BaseUrl = new Uri("https://gatewayapi.com/");
            IRestResponse response = this.Request(RestSharp.Method.GET, "/api/prices/list/sms/json");
            this.client.BaseUrl = new Uri("https://gatewayapi.com/rest/");
            return Prices.ParseResponse(response);
        }

        /// <summary>
        /// Cancel a scheduled SMS
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public CancelResult CancelScheduledMessage(long messageId)
        {
            IRestResponse response = this.Request(RestSharp.Method.DELETE, $"mtsms/{messageId}");
            return CancelResult.ParseResponse(messageId, response.StatusCode);            
        }

        /// <summary>
        /// Perform request to GatewayAPI
        /// </summary>
        private IRestResponse Request(RestSharp.Method method, string endPoint, string body = "")
        {
            var request = new RestSharp.RestRequest(endPoint, method);
            if (body != "")
            {
                request.AddJsonBody(body);
            }

            try
            {
                var response = client.Execute(request);
                        
                if ((int)response.StatusCode != 200 && (int) response.StatusCode != 204)
                { 
                    if ((int)response.StatusCode == 401)
                    {
                        throw new UnauthorizedException(response.Content);
                    } else if ((int)response.StatusCode == 422) {
                        throw new MessageException(response.Content);
                    } else if ((int)response.StatusCode >= 500 || (int)response.StatusCode == 0)
                    {
                        throw new ServerException(response.Content);
                    } 
                    throw new Exception(response.Content);
                }

                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
