using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GatewayAPI.Entities
{
    
    public class SMSMessage
    {
        [JsonProperty("class")]
        protected string Type { get; set; } = SMSType.Standard;

        [JsonProperty("message")]
        protected string Message {get; set;}

        [JsonProperty("sender")]
        protected string Sender { get; set; }

        [JsonProperty("sendtime")]
        protected int? SendTime { get; set; } = null;

        [JsonProperty("tags")]
        protected List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("userref")]
        protected string UserRef { get; set; }

        [JsonProperty("priority")]
        protected string Priority { get; set; }

        [JsonProperty("validity_period")]
        protected int? ValidityPeriod { get; set; } = null;

        [JsonProperty("encoding")]
        protected string Encoding { get; set; } = "UTF8";

        [JsonProperty("destaddr")]
        protected string DestAddr {get; set; }

        [JsonProperty("payload")]
        protected string Payload { get; set; }

        [JsonProperty("udh")]
        protected string Udh { get; set; }

        [JsonProperty("callback_url")]
        protected string CallbackUrl { get; set; }

        [JsonProperty("label")]
        protected string Label { get; set; }

        [JsonProperty("max_parts")]
        protected int? MaxParts { get; set; } = null;

        [JsonProperty("extra_details")]
        protected string ExtraDetails { get; set; }

        [JsonProperty("recipients")]
        protected List<SMSRecipient> Recipients { get; set; } = new List<SMSRecipient>();        

        /// <summary>
        /// Generates the field json to send to API
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            var settings = new JsonSerializerSettings() { 
                ContractResolver = new JsonResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };            
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, settings);
        }

        /// <summary>
        /// Get recipients
        /// </summary>
        /// <returns></returns>
        public List<SMSRecipient> GetRecipients()
        {
            return this.Recipients;
        }

        /// <summary>
        /// Set recipient
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public SMSMessage SetRecipient(SMSRecipient recipient)
        {
            this.Recipients.Add(recipient);
            return this;
        }

        /// <summary>
        /// Get extra details
        /// </summary>
        /// <returns></returns>
        public string GetExtraDetails()
        {
            return this.ExtraDetails;
        }

        /// <summary>
        /// To get more details about the number of parts sent to each recipient set this to ‘recipients_usage’. See example response below.
        /// </summary>
        /// <param name="extraDetails"></param>
        /// <returns></returns>
        public SMSMessage SetExtraDetails(string extraDetails)
        {
            this.ExtraDetails = extraDetails;
            return this;
        }

        /// <summary>
        /// Get max parts
        /// </summary>
        /// <returns></returns>
        public int? GetMaxParts()
        {
            return this.MaxParts;
        }

        /// <summary>
        /// A number between 1 and 255 used to limit the number of smses a single message will send. Can be used if you send smses from systems that generates messages that you can’t control, this way you can ensure that you don’t send very long smses. You will not be charged for more than the amount specified here. Can’t be used with Tags or BINARY smses.
        /// </summary>
        /// <param name="maxParts"></param>
        /// <returns></returns>
        public SMSMessage SetMaxParts(int maxParts)
        {
            this.MaxParts = maxParts;
            return this;
        }

        /// <summary>
        /// Get label
        /// </summary>
        /// <returns></returns>
        public string GetLabel()
        {
            return this.Label;
        }

        /// <summary>
        /// A label added to each sent message, can be used to uniquely identify a customer or company that you sent the message on behalf of, to help with invoicing your customers. If specied it must be the same for all messages in the request.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public SMSMessage SetLabel(string label)
        {
            this.Label = label;
            return this;
        }

        /// <summary>
        /// Get callback url
        /// </summary>
        /// <returns></returns>
        public string GetCallbackUrl()
        {
            return this.CallbackUrl;
        }

        /// <summary>
        /// If specified send status notifications to this URL, else use the default webhook.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public SMSMessage GetCallbackUrl(string url)
        {
            this.CallbackUrl = url;
            return this;
        }

        /// <summary>
        /// Get UDH 
        /// </summary>
        /// <returns></returns>
        public string GetUdh()
        {
            return this.Udh;
        }

        /// <summary>
        /// Set UDH field
        /// </summary>
        /// <param name="udh"></param>
        /// <returns></returns>
        public SMSMessage SetUdh(string udh)
        {
            this.Udh = udh;
            return this;
        }

        /// <summary>
        /// Get payload
        /// </summary>
        /// <returns></returns>
        public string GetPayload()
        {
            return this.Payload;
        }

        /// <summary>
        /// Set payload
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public SMSMessage SetPayload(string payload)
        {
            this.Payload = payload;
            return this;
        }

        /// <summary>
        /// Get Dest addr
        /// </summary>
        /// <returns></returns>
        public string GetDestAddr()
        {
            return this.DestAddr;
        }

        /// <summary>
        /// One of ‘DISPLAY’, ‘MOBILE’, ‘SIMCARD’, ‘EXTUNIT’. Use display to do “flash sms”, a message displayed on screen immediately but not saved in the normal message inbox on the mobile device.
        /// </summary>
        /// <param name="destAddr"></param>
        /// <returns></returns>
        public SMSMessage SetDestAddr(string destAddr)
        {
            if (destAddr != SMSDestAddr.Mobile && destAddr != SMSDestAddr.Display && destAddr != SMSDestAddr.Simcard && destAddr != SMSDestAddr.Extunit) {
                throw new ArgumentException("SMS class must be one of 'mobile', 'display', 'simcard' or 'extunit'. You provided: " + destAddr);
            }
            this.DestAddr = destAddr;
            return this;            
        }

        /// <summary>
        /// Get encoding
        /// </summary>
        /// <returns></returns>
        public string GetEncoding()
        {
            return this.Encoding;
        }

        /// <summary>
        /// Encoding to use when sending the message. Defaults to ‘UTF8’, which means we will use GSM 03.38. Use UCS2 to send a unicode message.
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public SMSMessage SetEncoding(string encoding)
        {
            this.Encoding = encoding;
            return this;
        }

        /// <summary>
        /// Get Validity Period
        /// </summary>
        /// <returns></returns>
        public int? GetValidityPeriod()
        {
            return this.ValidityPeriod;
        }

        /// <summary>
        /// If message is not delivered within this timespan, it will expire and you will get a notification. The minimum value is 60. Every value under 60 will be set to 60.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public SMSMessage SetValidityPeriod(int seconds) 
        {
            this.ValidityPeriod = seconds;
            return this;
        }

        /// <summary>
        /// Get userref
        /// </summary>
        /// <returns></returns>
        public string GetUserRef()
        {
            return this.UserRef;
        }

        /// <summary>
        /// Set userref
        /// </summary>
        /// <param name="userRef"></param>
        /// <returns></returns>
        public SMSMessage SetUserRef(string userRef)
        {
            this.UserRef = userRef;
            return this;
        }

        /// <summary>
        /// Set tags
        /// </summary>
        /// <param name="tags"></param>
        public SMSMessage SetTags(List<string> tags)
        {
            this.Tags = tags;
            return this;
        }   

        /// <summary>
        /// Set a single tag
        /// </summary>
        /// <param name="tag"></param>
        public SMSMessage SetTag(string tag)
        {
            this.Tags.Add(tag);
            return this;
        }

        /// <summary>
        /// Set the send time of the SMS
        /// </summary>
        /// <param name="sendTime"></param>
        public SMSMessage SetSendTime(DateTime sendTime)
        {
            this.SendTime = (int)((DateTimeOffset)sendTime).ToUnixTimeSeconds();
            return this;
        }

        /// <summary>
        /// Sets sender of SMS - Rule says "Up to 11 alphanumeric characters, or 15 digits, that will be shown as the sender of the SMS"
        /// </summary>
        /// <param name="sender"></param>
        public SMSMessage SetSender(string sender)
        {
            this.Sender = sender;
            return this;
        }

        /// <summary>
        /// Get the sender of the SMS
        /// </summary>
        /// <returns></returns>
        public string GetSender()
        {
            return this.Sender;
        }

        /// <summary>
        /// Set the content/message of the SMS
        /// </summary>
        /// <param name="message"></param>
        public SMSMessage SetMessage(string message)
        {
            this.Message = message;
            return this;
        }

        /// <summary>
        /// Get the content/message of the SMS
        /// </summary>
        /// <param name="message"></param>
        public string GetMessage()
        {
            return this.Message;
        }

        /// <summary>
        /// Sets SMS class. Must be one of 'standard', 'premium' or 'secret'
        /// </summary>
        /// <param name="type"></param>
        public SMSMessage SetClass(string type)
        {
            if (type != SMSType.Secret && type != SMSType.Premium && type != SMSType.Standard) {
                throw new ArgumentException("SMS class must be one of 'standard', 'premium' or 'secret'. You provided: " + type);
            }
            this.Type = type;
            return this;
        }

        /// <summary>
        /// Get SMS class        
        /// </summary>
        /// <returns></returns>
        public string GetClass()
        {
            return this.Type;
        }

         /// <summary>
        /// Sets SMS priority. Must be one of ‘BULK’, ‘NORMAL’, ‘URGENT’ and ‘VERY_URGENT’
        /// </summary>
        /// <param name="priority"></param>
        public SMSMessage SetPriority(string priority)
        {
            if (priority != SMSPriority.Normal && priority != SMSPriority.Bulk && priority != SMSPriority.Urgent && priority != SMSPriority.VeryUrgent) {
                throw new ArgumentException("SMS class must be one of 'BULK', 'NORMAL', 'URGENT' and 'VERY_URGENT'. You provided: " + priority);
            }
            this.Priority = priority;
            return this;
        }

        /// <summary>
        /// Get SMS class        
        /// </summary>
        /// <returns></returns>
        public string GetPriority()
        {
            return this.Priority;
        }

        /// <summary>
        /// Identifies if Tags should be sent
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTags()
        {
            // don't serialize the Manager property if an employee is their own manager
            return (Tags.Count > 0);
        }
    }
}