using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace InteleSmsMessagingKit
{
    /// <summary>
    /// Check if number is a valid international mobile number. Service must be enabled for your account
    /// </summary>
	public class NumberplanFactory
    {
        /// <summary>
        /// Query MSISDN information using default login from app.config
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static NumberplanService.NumberInfo CheckNumberplan(long phoneNumber)
        {
            var client = new NumberplanService.NumberplanPublicSoapClient("NumberplanSoap12");

            var auth = new NumberplanService.Authorizer {
                ApiCustomerId = int.Parse(ConfigurationManager.AppSettings["InteleApiCustomerId"]),
                ApiPassword = ConfigurationManager.AppSettings["InteleApiPassword"]
            };

            var result = client.Query(auth, phoneNumber);

            return result;
        }

    }
}
