using System;
using Xunit;
using GatewayAPI.Entities;

namespace GatewayAPI.Tests
{
    public class SMSRecipientTest
    {

        [Fact]
        public void TestValidConstruct()
        {            
            SMSRecipient recipient = new SMSRecipient(4511111111);            
            Assert.True((recipient.GetPhoneNumber() == 4511111111));
        }
    }
}
