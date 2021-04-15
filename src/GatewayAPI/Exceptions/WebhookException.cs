using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Exceptions
{
    public class WebhookException : Exception
    {
        public WebhookException(string message) : base(message) { }
    }
}
