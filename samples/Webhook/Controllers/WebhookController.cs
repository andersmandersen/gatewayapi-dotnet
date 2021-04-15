using System;
using GatewayAPI;
using GatewayAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Webhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : ControllerBase
    {        
        [HttpPost]
        public IActionResult Catch()
        {
            var webhookHandler = new GatewayAPIWebhookHandler("secret");
            var webhook = webhookHandler.ParseFromRequest(Request);

            if (webhook is WebhookDeliveryStatus)
            {
                WebhookDeliveryStatus test = (WebhookDeliveryStatus)webhook;
                Console.WriteLine(test.status);
            } else if (webhook is WebhookIncomingMessage) {
                WebhookIncomingMessage test = (WebhookIncomingMessage)webhook;
                Console.WriteLine(test.message);
            }

            return Ok();
        }
    }
}
