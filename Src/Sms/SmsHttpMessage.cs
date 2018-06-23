using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InteleSmsMessagingKit
{
    /// <summary>
    /// Sms message class
    /// </summary>
	public class SmsHttpMessage
	{
        /// <summary>
        /// Your API user Id / Customer Id
        /// </summary>
		public int CustomerId { get;set; }

        /// <summary>
        /// Your API password
        /// </summary>
		public string CustomerPassword { get; set; }

        /// <summary>
        /// Gateway to use for sending message
        /// </summary>
		public long GatewayNumber { get; set; }

        /// <summary>
        /// Originator of message
        /// </summary>
		public string OriginatorAddress { get; set; }

        /// <summary>
        /// Recipient for message
        /// </summary>
		public long DestinationAddress { get; set; }

		/// <summary>
		/// Used for grouping the messages on salary
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// Normaly use value of 11. That will split up messages into correct parts at the remote server.
		/// </summary>
		public string MessageType { get; set; }

        /// <summary>
        /// Price in ØRE
        /// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Unique referense id of the message we're sending. To track delivery status
		/// </summary>
		public string MessageId { get; set; }

        /// <summary>
        /// Where you want the delivery report to be sent (script on your server)
        /// </summary>
		public string DeliveryStatusUrl { get; set; }

        /// <summary>
        /// 1 - 3. 1 is most important. 3 is least important
        /// </summary>
        public int Qos { get; set; } = 3;

        /// <summary>
        /// Data coding scheme
        /// </summary>
		public int DataCodingScheme { get; set; }

        /// <summary>
        /// Set expires timestamp for the message
        /// </summary>
		public DateTime? Expires { get; set; }

		/// <summary>
		/// The text message to send
		/// </summary>
		public string UserData { get; set; }

		/// <summary>
		/// Used with Sms dialog only
		/// </summary>
		public string Keyword { get; set; }

		/// <summary>
		/// Used with Sms dialog only
		/// </summary>
		public string SubnumRef { get; set; }

        /// <summary>
        /// Used for billing / premium SMS
        /// </summary>
        public string BusinessModel { get; set; }

        /// <summary>
        /// Used for billing / premium SMS
        /// </summary>
        public string ServiceCode { get; set; }

        /// <summary>
        /// Generate URL with all parameters
        /// </summary>
        /// <returns></returns>
		public string ToUrl()
		{
			Encoding enc = Encoding.GetEncoding("ISO-8859-1");

            //Encoding enc = Encoding.UTF8; //If using this, you'll ned to add parameter to url: &encoding=utf-8

            StringBuilder strB = new StringBuilder();
			strB.AppendFormat("CustomerId={0}&Password={1}&Category={2}&Gateway={3}&MessageId={4}&MessageType={5}&dcs={6}&OriginatorAddress={7}&DestinationAddress={8}&vp={9}&DeliveryReportUrl={10}&Price={11}&priority={12}&keyword={13}&subnumref={14}&UserData={15}&BusinessModel={16}&ServiceCode={17}", 
				this.CustomerId,
				HttpUtility.UrlEncode(this.CustomerPassword, enc),
				HttpUtility.UrlEncode(this.Category, enc),
				this.GatewayNumber,
				HttpUtility.UrlEncode(this.MessageId, enc),
				HttpUtility.UrlEncode(this.MessageType, enc), 
				this.DataCodingScheme,
				HttpUtility.UrlEncode(this.OriginatorAddress, enc),
				this.DestinationAddress,
				(this.Expires.HasValue?this.Expires.Value.ToString("ddMMyyyyHHmmss"):""),
				HttpUtility.UrlEncode(this.DeliveryStatusUrl, enc),
				this.Price,
				this.Qos,
				HttpUtility.UrlEncode("" + this.Keyword, enc),
				HttpUtility.UrlEncode("" + this.SubnumRef, enc),
				HttpUtility.UrlEncode(this.UserData, enc),
                HttpUtility.UrlEncode(this.BusinessModel, enc),
                HttpUtility.UrlEncode(this.ServiceCode, enc));

	
			return strB.ToString();
		}
	}
}
