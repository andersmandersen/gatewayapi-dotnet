using GatewayAPI;
using GatewayAPI.Entities;
using GatewayAPI.Exceptions;
using GatewayAPI.Responses;
using System;

namespace SendingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            GatewayAPIHandler handler = new GatewayAPIHandler("apiToken");

            // Create message
            SMSMessage message = new SMSMessage()
                            .SetMessage("Hello World")
                            .SetRecipient(new SMSRecipient(4512345678));

            // Send message
            try
            {
                Result result = handler.SendMessage(message);
                Console.WriteLine(result.Ids); // Returns a list of ids.
            }
            catch (UnauthorizedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MessageException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
