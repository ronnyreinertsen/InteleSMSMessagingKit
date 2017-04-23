using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InteleSmsMessagingKit
{
    /// <summary>
    /// Factory class for sending messages via HTTP API
    /// </summary>
    public class SmsFactory
    {

        /// <summary>
        /// Send Sms message using defaults from app.config
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static SendHttpResponse.SendSmsResult SendSms(SmsHttpMessage message)
        {
            return SmsMessageHttpClient.SendMessage(message);
        }


        /// <summary>
        /// Used to send sms message with input parameters
        /// </summary>
        /// <param name="customerId">Your customer id from Intele AS</param>
        /// <param name="customerPassword">Your password from Intele AS</param>
        /// <param name="gateway">Use 99700999 for world-wide free messages</param>
        /// <param name="price">Price in ØRE</param>
        /// <param name="messageId">Id from your database to identify the message in status response</param>
        /// <param name="destinationAddress">Recipient MSISDN</param>
        /// <param name="originatorAddress">Numeric or alphanumeric sender address</param>
        /// <param name="textMessage">The message to send to recipient</param>
        /// <param name="category">Categorize messages in groups in invoice/bill from Intele</param>
        /// <param name="drUrl">The url where you will receive delivery reports</param>
        /// <param name="qos">Priority. Value 1-3 where 1 is the most important</param>
        /// <param name="messageType">Use 11 as default to support long SMS messages exeeding 160 chars</param>
        /// <param name="businessModel"></param>
        /// <param name="serviceCode"></param>
        /// <returns></returns>
        public static SendHttpResponse.SendSmsResult SendSmsWithParameters(int customerId, string customerPassword, long gateway, int price, string messageId,
            long destinationAddress, string originatorAddress,
            string textMessage, string category, string drUrl, int qos, string messageType, string businessModel, string serviceCode)
        {

            var newMessage = new SmsHttpMessage
            {
                CustomerId = customerId,
                CustomerPassword = customerPassword,
                GatewayNumber = gateway,
                DestinationAddress = destinationAddress,
                OriginatorAddress = originatorAddress,
                Price = price,
                MessageType = messageType,
                Category = category,
                DeliveryStatusUrl = drUrl,
                MessageId = messageId,
                UserData = textMessage,
                Expires = DateTime.Now.AddDays(1), //<- default expires after 24 hours.
                Qos = qos,
                BusinessModel = businessModel,
                ServiceCode = serviceCode
            };
               
            
            SendHttpResponse.SendSmsResult sendResponse = InteleSmsMessagingKit.SmsFactory.SendSms(newMessage);                 
            
            return sendResponse;

        }
    }
}
