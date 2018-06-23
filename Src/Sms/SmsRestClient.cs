using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteleSmsMessagingKit.Sms
{

    /// <summary>
    /// Client for executing REST query
    /// </summary>
    public static class SmsRestClient
    {
        /// <summary>
        /// Send message using Rest Dto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dto.RestSmsResponse ExecuteRestApiCall(Dto.RestSmsRequest request)
        {

            //Create client for accessing REST Api
            var client = new JsonServiceClient(Dto.RestApiGlobals.RestApiBaseUri)
            {
                Timeout = TimeSpan.FromSeconds(120),
                UserAgent = "Rest API test client",
                ResponseFilter = res => res.StatusCode.ToString().Print()
            };
                        
            var sendResp = client.Post(request);

            client.Dispose();
            client = null;

            return sendResp;



        }

    }
}
