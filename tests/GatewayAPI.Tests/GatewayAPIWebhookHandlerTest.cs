using GatewayAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GatewayAPI.Tests
{
    public class GatewayAPIWebhookHandlerTest
    {

        [Fact]
        public void TestCanDecryptToken()
        {
            var webhookHandler = new GatewayAPIWebhookHandler("secret");
            var result = webhookHandler.ValidateToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6MTUzMjU4MzA3OCwibXNpc2RuIjo0NTI4OTUwMzcyLCJ0aW1lIjoxNjE2NDA0MjYwLjAsInN0YXR1cyI6IkRFTElWRVJFRCIsInVzZXJyZWYiOm51bGwsImNvdW50cnlfY29kZSI6IkRLIiwiY291bnRyeV9wcmVmaXgiOjQ1fQ.JSyTji-WGqlM8gkuT7I68lddduQ7A-ydcdirIzoHmNM");

            Assert.True(result is string);
        }

        [Fact]
        public void TestCanDecryptTokenToWebhookDeliveryStatus()
        {
            var webhookHandler = new GatewayAPIWebhookHandler("secret");
            var result = webhookHandler.ParseFromToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6MTUzMjU4MzA3OCwibXNpc2RuIjo0NTI4OTUwMzcyLCJ0aW1lIjoxNjE2NDA0MjYwLjAsInN0YXR1cyI6IkRFTElWRVJFRCIsInVzZXJyZWYiOm51bGwsImNvdW50cnlfY29kZSI6IkRLIiwiY291bnRyeV9wcmVmaXgiOjQ1fQ.JSyTji-WGqlM8gkuT7I68lddduQ7A-ydcdirIzoHmNM");

            Assert.True(result is WebhookDeliveryStatus);
        }

        [Fact]
        public void TestCanDecryptTokenToWebhookIncomingMessage()
        {
            var webhookHandler = new GatewayAPIWebhookHandler("secret");
            var result = webhookHandler.ParseFromToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6MTAwMDAwMSwibXNpc2RuIjo0NTg3NjU0MzIxLCJyZWNlaXZlciI6NDUxMjA0LCJtZXNzYWdlIjoidGVzdCBtZXNzYWdlIiwic2VudHRpbWUiOjE2MTg0NzM2NzksIndlYmhvb2tfbGFiZWwiOiJGaXNvbHUiLCJjb3VudHJ5X2NvZGUiOm51bGwsImNvdW50cnlfcHJlZml4IjpudWxsfQ.-0kZ-w6d-dBoCQr_HPVO6hrmEqQGysTiUt9g8DKsqDE");

            Assert.True(result is WebhookIncomingMessage);
        }
    }
}
