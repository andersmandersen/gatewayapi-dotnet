# 📧 GatewayAPI .NET

GatewayAPI .NET is a wrapper for the GatewayApi RestAPI. For full description of the GatewayAPI see: https://gatewayapi.com/docs/

## 🔧 Installation

Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```bash
$ dotnet add package GatewayAPI
```

or with the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```bash
$ Install-Package GatewayAPI
```

## 👷‍♀️ Usage
The API wrapper is build with the mindset of been simple to use. The package utilities fluent princip.

For further documentation visit the /Sample folder

### Sending a SMS
```c#

// Construct handler
GatewayAPIHandler handler = new GatewayAPIHandler("apiToken");

// Create message
SMSMessage message = new SMSMessage()
                .SetMessage("Hello World")                
                .SetRecipient(new SMSRecipient(4512345678));

// Send message
try
{
    Result result = gatewayAPIHandler.SendMessage(message);
    Console.WriteLine(result.Ids); // Returns a list of ids .
} catch (UnauthorizedException e)
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
} catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// You can send multiple message with the following function
Result result = gatewayAPIHandler.SendMessage(message);
gatewayAPIHandler.SendMessages(new List<SMSMessage> {
                    message,
                    message2
                });
```

### Get Account balance
Get the current account balance from GatewayAPI

```C#
GatewayAPIHandler gatewayAPIHandler = new GatewayAPIHandler("apiToken");            
AccountBalance accountBalance = gatewayAPIHandler.GetAccountBalance();
```

### Get Prices
Fetch current prices from GatewayAPI. 

```C#
GatewayAPIHandler gatewayAPIHandler = new GatewayAPIHandler("apiToken");            
Prices prices = gatewayAPIHandler.GetPricesAsJson();
```

### Cancel a scheduled SMS
You can cancel a scheduled message from the returned ID, when sending the message

```C#

GatewayAPIHandler gatewayAPIHandler = new GatewayAPIHandler("apiToken");            

// Construct a schduled message
DateTime dt = DateTime.Now;
SMSMessage message = new SMSMessage()
                        .SetMessage("Tester")
                        .SetSender("Test")
                        .SetSendTime(dt.AddHours(1))                                    
                        .SetRecipient(new SMSRecipient(4512345678));

// Send message
Result result = gatewayAPIHandler.SendMessage(message);

// Cancel the first message
CancelResult cancelResult = gatewayAPIHandler.CancelScheduledMessage(result.Ids[0]);
string result = cancelResult.Status // (Can either return failed or success)
```

## 📎 Contact

If you find and issue, please create a issue. You can at any time reach out to me on [twitter](https://twitter.com/snuswdk)


# Todo: 

* Setup respository - Private, then publich

https://github.com/nickdnk/gatewayapi-php