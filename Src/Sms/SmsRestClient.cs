using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PushSmsLib.Dto;
using System.Net.Http;
using Newtonsoft.Json;

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
		public static RestSmsResponse ExecuteRestApiCall(RestSmsRequest request)
		{

			RestSmsResponse resp = null;

			//Create client for accessing REST Api
			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
				var response = httpClient.PostAsync(Dto.RestApiGlobals.RestApiBaseUri + "/json/reply/RestSmsRequest", content).GetAwaiter().GetResult();
				string apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				resp = JsonConvert.DeserializeObject<RestSmsResponse>(apiResponse);
			}

			return resp;



		}

	}
}
