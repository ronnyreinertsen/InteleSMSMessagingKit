using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace InteleSmsMessagingKit
{

    /// <summary>
    /// Response object returned after sending sms message to API
    /// </summary>
    public class SendHttpResponse
    {

        /// <summary>
        /// Function to parse server response from send sms API
        /// </summary>
        /// <param name="xmldata">Xml response from server</param>
        /// <returns></returns>
        public static SendSmsResult Parse(byte[] xmldata)
        {
   
            var result = new SendSmsResult();

            var xDoc = new System.Xml.XmlDocument();
            System.Xml.XmlNode rootNode;
            xDoc.LoadXml(Encoding.UTF8.GetString(xmldata));
            rootNode = xDoc["root"].FirstChild;

            result.Message = (rootNode["message"] != null && !string.IsNullOrEmpty(rootNode["message"].InnerText)) ? rootNode["message"].InnerText : "";
            result.ErrorCode = (rootNode["error_code"] != null && !string.IsNullOrEmpty(rootNode["error_code"].InnerText)) ? Int32.Parse(rootNode["error_code"].InnerText) : new Nullable<int>();
            result.ErrorMessage = (rootNode["error_message"] != null && !string.IsNullOrEmpty(rootNode["error_message"].InnerText)) ? rootNode["error_message"].InnerText : "";
            result.Success = (rootNode["error"].InnerText == "0");
            result.ExtraData = (rootNode["exstra_info"] != null && !string.IsNullOrEmpty(rootNode["exstra_info"].InnerText)) ? rootNode["exstra_info"].InnerText : "";

            xDoc = null;
            rootNode = null;

            return result;
        }

        /// <summary>
        /// Parsed server response object
        /// </summary>
        public class SendSmsResult
        {
            /// <summary>
            /// True if message successfully sent
            /// </summary>
            public bool Success;
            /// <summary>
            /// Zero if success, otherwise error code according to documentation
            /// </summary>
            public int? ErrorCode;
            /// <summary>
            /// Error description if available
            /// </summary>
            public string ErrorMessage;
            /// <summary>
            /// Standard response message from server
            /// </summary>
            public string Message;
            /// <summary>
            /// Comma seperated list of name/value collection. Returns server name as default. But also returns subnumref when used to create two-way messaging
            /// </summary>
            public string ExtraData;
        }
     

    }


}
