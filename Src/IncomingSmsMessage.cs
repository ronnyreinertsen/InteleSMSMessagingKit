using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace InteleSmsMessagingKit
{
    /// <summary>
    /// Class that holds variables for a SMS MO message
    /// </summary>
	public class IncomingSmsMessage
    {
        //TEST URL:
        /*

        https://yourhostname.com/ReceiveSms?
        &gateway=[$GW]
        &operator_id=[$OPERATOR_ID]
        &msg_header=[$USERDATAHEADER]
        &msg_type=[$MSG_TYPE]
        &message=[$USERDATA]
        &fromnumber=[$ORIGINATOR]
        &timestamp=[$CPA_TIMESTAMP]
        &message_id=[$MESSAGE_ID]
        &customer_id=[$CUSTOMER_ID]
        &sms_keyword=[$KEYWORD]
        &msg_timestamp=[$MSG_TIMESTAMP]
        
        */

        /// <summary>
        /// Parse name value collection from url
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IncomingSmsMessage Parse(NameValueCollection values)
        {
            //Get route variables to determine what country, customer and chain the sms message is for

            int dataCount = 0;
            if (values == null || values.Count == 0)
            {
                throw new MissingFieldException("Missing data!");
            }

            IncomingSmsMessage retVal = new IncomingSmsMessage();
            if (!string.IsNullOrEmpty(values["customer_id"]))
            {
                retVal.CustomerId = Int32.Parse(values["customer_id"]);
                ++dataCount;
            }

            if (!string.IsNullOrEmpty(values["message_id"]))
            {
                retVal.MessageId = Int32.Parse(values["message_id"]);
                ++dataCount;
            }

            if (!string.IsNullOrEmpty(values["gateway"]))
            {
                retVal.DestinationNumber = values["gateway"].Trim();
                ++dataCount;
            }

            if (!string.IsNullOrEmpty(values["country_id"]))
            {
                retVal.CountryId = int.Parse(values["country_id"]);
                ++dataCount;
            }

            if (!string.IsNullOrEmpty(values["fromnumber"]))
            {
                retVal.OriginatorAddress = long.Parse(values["fromnumber"]);
                ++dataCount;
            }

            if (!string.IsNullOrEmpty(values["sms_keyword"]))
            {
                retVal.Keyword = values["sms_keyword"];
                ++dataCount;
            }

            if (!string.IsNullOrEmpty(values["DestinationAddress"]))
            {
                retVal.DestinationAddress = values["DestinationAddress"];
                ++dataCount;
            }

            if (values["message"] != null)
            {
                retVal.UserData = values["message"];
                ++dataCount;
            }

            /*
            //Validate inputs?
            if (dataCount < 6)
            {
                throw new MissingFieldException("Invalid data!");
            }
            */
            return retVal;

        }

        /// <summary>
        /// Customer Id that received the message
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Message id from server
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Country id from server
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Destination address. E.g. +4799700999, 1933, 1960 etc.
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Destination number for the message. E.g 99700999, 1933. Same as DestinationAddress, but without country prefix and leading +
        /// </summary>
        public string DestinationNumber { get; set; }

        /// <summary>
        /// Sender of the message
        /// </summary>
        public long OriginatorAddress { get; set; }

        /// <summary>
        /// Property from MMS message
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Only contains the first keyword of a message
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Contains the actual text message including the initial keyword
        /// </summary>
        public string UserData { get; set; }

    }
}
