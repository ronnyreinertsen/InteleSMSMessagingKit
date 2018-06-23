using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using InteleSmsMessagingKit.Sms;

namespace InteleSmsMessagingKit
{
    /// <summary>
    /// Factory class for sending messages via HTTP API
    /// </summary>
    public class SmsFactory
    {

        /// <summary>
        /// Send message(es) using REST API Client
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Dto.RestSmsResponse SendSms(Dto.RestSmsRequest message)
        {

            //Check if we need to read from app.config
            if (string.IsNullOrEmpty(message.Username))
                message.Username = ConfigurationManager.AppSettings["InteleApiCustomerId"];

            if (string.IsNullOrEmpty(message.Password))
                message.Password = ConfigurationManager.AppSettings["InteleApiPassword"];

            string customData = ConfigurationManager.AppSettings["SmsMessageCustomData"];
            foreach (var msg in message.Messages)
            {
                if (msg.CustomData == null || msg.CustomData.Count == 0)
                {
                    foreach (var addString in customData.Split(','))
                    {
                        msg.CustomData.Add(addString.Split('=')[0], addString.Split('=')[1]);
                    }
                }
                    
            }
            

            return Sms.SmsRestClient.ExecuteRestApiCall(message);
        }

        /// <summary>
        /// Send Sms message using defaults from app.config
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static SendHttpResponse.SendSmsResult SendSms(SmsHttpMessage message)
        {

            //Check if we need to read from app.config
            if (message.CustomerId <= 0)
                message.CustomerId = int.Parse(ConfigurationManager.AppSettings["InteleApiCustomerId"]);

            if (string.IsNullOrEmpty(message.CustomerPassword))
                message.CustomerPassword = ConfigurationManager.AppSettings["InteleApiPassword"];

            return SmsMessageHttpClient.SendMessage(message);
        }

        /// <summary>
        /// Send SMS using SOAP API
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static SmsSoapApi.ResponseObj SendSms(SmsSoapApi.SendSMSRequest message)
        {

            //Check if we need to read from app.config
            if (message.Authorizer.CustomerID <= 0)
                message.Authorizer.CustomerID = int.Parse(ConfigurationManager.AppSettings["InteleApiCustomerId"]);

            if (string.IsNullOrEmpty(message.Authorizer.Password))
                message.Authorizer.Password = ConfigurationManager.AppSettings["InteleApiPassword"];

            if (string.IsNullOrEmpty(message.smsObj.CustomData))
                message.smsObj.CustomData = ConfigurationManager.AppSettings["SmsMessageCustomData"];

            return SoapClient.SendMessage(message);
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
