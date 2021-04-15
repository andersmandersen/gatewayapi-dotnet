using System;
using Xunit;
using GatewayAPI.Entities;

namespace GatewayAPI.Tests
{
    public class SMSMessageTest
    {

        [Fact]
        public void TestInvalidClass()
        {
            SMSMessage message = new SMSMessage();
            Assert.Throws<ArgumentException>(() => message.SetClass("something"));
        }

        [Fact]
        public void TestValidClass()
        {
            SMSMessage message = new SMSMessage();
            message.SetClass(SMSType.Standard);

            Assert.True((SMSType.Standard == message.GetClass()));
        }

        [Fact]
        public void TestInvalidPriority()
        {
            SMSMessage message = new SMSMessage();
            Assert.Throws<ArgumentException>(() => message.SetPriority("something"));
        }

        [Fact]
        public void TestValidPriority()
        {
            SMSMessage message = new SMSMessage();
            message.SetPriority(SMSPriority.VeryUrgent);

            Assert.True((SMSPriority.VeryUrgent == message.GetPriority()));
        }

        [Fact]
        public void TestInvalidDestAddr()
        {
            SMSMessage message = new SMSMessage();
            Assert.Throws<ArgumentException>(() => message.SetDestAddr("something"));
        }

        [Fact]
        public void TestValidDestAddr()
        {
            SMSMessage message = new SMSMessage();
            message.SetDestAddr(SMSDestAddr.Mobile);

            Assert.True((SMSDestAddr.Mobile == message.GetDestAddr()));
        }

        [Fact]
        public void TestConstructValidSMS()
        {
            SMSMessage message = new SMSMessage()
                                    .SetMessage("Hello World")                                    
                                    .SetRecipient(new SMSRecipient(4512345678));
            
            Assert.True(message.ToJson() == "{\"class\":\"standard\",\"message\":\"Hello World\",\"encoding\":\"UTF8\",\"recipients\":[{\"msisdn\":4512345678}]}");
        }
    }
}
