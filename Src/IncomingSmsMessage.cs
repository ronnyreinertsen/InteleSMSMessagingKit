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
    /// Class that holds variables for an SMS MO message
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
            if (values["customer_id"] != null)
            {
                retVal.CustomerId = Int32.Parse(values["customer_id"]);
                ++dataCount;
            }

            if (values["message_id"] != null)
            {
                retVal.MessageId = Int32.Parse(values["message_id"]);
                ++dataCount;
            }

            if (values["gateway"] != null)
            {
                retVal.DestinationNumber = values["gateway"].Trim();
                ++dataCount;
            }

            if (values["country_id"] != null)
            {
                retVal.CountryId = int.Parse(values["country_id"]);
                ++dataCount;
            }

            if (values["fromnumber"] != null)
            {
                retVal.OriginatorAddress = long.Parse(values["fromnumber"]);
                ++dataCount;
            }

            if (values["sms_keyword"] != null)
            {
                retVal.Keyword = values["sms_keyword"];
                ++dataCount;
            }

            if (values["message"] != null)
            {
                retVal.UserData = values["message"];
                ++dataCount;
            }

            if (dataCount < 6)
            {
                throw new MissingFieldException("Invalid data!");
            }

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
        /// Destination address for the message
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
