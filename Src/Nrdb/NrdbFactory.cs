using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace InteleSmsMessagingKit
{
    /// <summary>
    /// Check number against Norwegian number registry. Service must be enabled for your account
    /// </summary>
	public class NrdbFactory
    {

        /// <summary>
        /// CheckNrdb using default login from app.config
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
		public static NrdbService.NrdbStatus CheckNrdb(long phoneNumber)
        {
            var client = new NrdbService.NrdbLookupServiceSoapClient();

            var auth = new NrdbService.LoginClass
            {
                CustomerId = Int32.Parse(ConfigurationManager.AppSettings["InteleApiCustomerId"]),
                Password = ConfigurationManager.AppSettings["InteleApiPassword"]
            };

            var result = client.Query(auth, phoneNumber);

            return result;

        }

    }
}
