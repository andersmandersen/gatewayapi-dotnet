using GatewayAPI.Exceptions;
using GatewayAPI.Interfaces;
using GatewayAPI.Responses;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace GatewayAPI
{
    public class GatewayAPIWebhookHandler
    {
        private readonly string _secret;

        public GatewayAPIWebhookHandler(string secret = "")
        {            
            this._secret = secret;
        }

        /// <summary>
        /// Parse request from webhook
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IWebhookResponse ParseFromRequest(HttpRequest request)
        {
            string token = this.GetTokenFromRequest(request);
            return this.ParseFromToken(token);
        }        

        /// <summary>
        /// Parse directly from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IWebhookResponse ParseFromToken(string token)
        {
            var payload = this.ValidateToken(token);
            JObject payloadObj = JObject.Parse(payload);

            if (payloadObj.ContainsKey("id")
                && payloadObj.ContainsKey("msisdn"))
            {

                // Delivery status webhook
                if (payloadObj.ContainsKey("time")
                    && payloadObj.ContainsKey("status"))
                {
                    return WebhookDeliveryStatus.ParseResponse(payload);
                }

                // Delivery status webhook
                if (payloadObj.ContainsKey("receiver")
                    && payloadObj.ContainsKey("message")
                    && payloadObj.ContainsKey("senttime")
                    && payloadObj.ContainsKey("webhook_label"))
                {
                    return WebhookIncomingMessage.ParseResponse(payload);
                }
            }

            throw new WebhookException("Failed to parse payload from webhook");
        }

        /// <summary>
        /// Get token from header value "X-Gwapi-Signature"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetTokenFromRequest(HttpRequest request)
        {
            if (!request.Headers.ContainsKey("X-Gwapi-Signature"))
            {
                throw new WebhookException("Failed to read JWT header.");
            }
            return request.Headers["X-Gwapi-Signature"];
        }

        /// <summary>
        /// Validate token from header value "X-Gwapi-Signature"
        /// </summary>
        /// <returns></returns>
        public string ValidateToken(string token)
        {
            try
            {                              
                var json = JwtBuilder.Create()
                                  .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                                  .WithSecret(this._secret)
                                  .MustVerifySignature()
                                  .Decode(token);
                return json;
            }
            catch (Exception e)
            {
                throw new WebhookException("Failed to validate X-Gwapi-Signature");
            }
            throw new WebhookException("Failed to validate X-Gwapi-Signature");
        }
    }
}
