using System;
using System.Collections.Generic;

namespace GatewayAPI.Entities
{    
    public class SMSRecipient
    {
        protected long msisdn { get; set; }
        protected List<string> Tagvalues { get; set; } = new List<string>();
        protected string CountryCode { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="tagValues"></param>
        /// <param name="countryCode"></param>
        public SMSRecipient(long phoneNumber, List<string> tagValues = null, string countryCode = null)
        {
            this.msisdn = phoneNumber;
            this.Tagvalues = tagValues;
            this.CountryCode = countryCode;            
        }

        /// <summary>
        /// Get phone number aka. msisdn
        /// </summary>
        /// <returns></returns>
        public long GetPhoneNumber()
        {
            return this.msisdn;
        }

        /// <summary>
        /// Get tag list
        /// </summary>
        /// <returns></returns>
        public List<string> GetTagValues()
        {
            return this.Tagvalues;            
        }

        /// <summary>
        /// Get country code
        /// </summary>
        /// <returns></returns>
        public string GetCountryCode()
        {
            if (this.CountryCode == "" || this.CountryCode == null) {
                throw new ArgumentNullException("Country code isn't defined for recipient");
            }

            return this.CountryCode;
        }

    }
}