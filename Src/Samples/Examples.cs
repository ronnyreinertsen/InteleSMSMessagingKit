using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Text;
using PushSmsLib.Dto;

namespace InteleSmsMessagingKit.Tests
{
	//Full manual: https://kunde.intele.no/files/SMS_Gateway_Implementation_Guide.pdf
	/// <summary>
	/// Class for doing some tests
	/// </summary>

	public static class Examples
	{

		/// <summary>
		/// Simple Send message test using REST API
		/// </summary>
		/// <param name="customerId"></param>
		/// <param name="password"></param>
		/// <param name="destinationAddress"></param>
		/// <param name="message"></param>
		public static void SendSmsMessageRestApi(int customerId, string password, long destinationAddress, string message)
		{
			//Create main request object
			var restRequest = new RestSmsRequest();
			restRequest.Username = customerId.ToString(); //Your Intele Customer Id
			restRequest.Password = password; //Your Intele Password

			//Create a message and store in temp list
			var msgList = new List<RestSmsMessageReq>();

			var addMsg = new RestSmsMessageReq
			{
				Category = "TEST-MESSAGES",
				DeliveryReportUrl = string.Empty, //Set to your server uri to receive delivery reports to verify that the message is delivered
				DestinationAddress = destinationAddress,
				Gateway = 99700999,
				MessageId = Guid.NewGuid().ToString().Replace("-", ""),
				MessageType = "11", //MessageType 11 allows more than default 160 characters. Message is automaticly splitted into parts on server using this MessageType value
				OriginatorAddress = "+4799700999", //Could be +4797513609 or any valid international mobile number
				Price = 0,
				ServiceCode = string.Empty,
				ServiceDescription = string.Empty,
				ValidationPeriod = DateTime.Now.AddHours(1).ToString("ddMMyyyyHHmmss"), //Set delivery to timeout if message is not received by end-user in 2 hours. 
				UserDataHeader = string.Empty, //Only used on concatenated messages, or binary messages with MessageType 10
				UserData = message,
				CustomData = addProps("qos=3")

			};
			msgList.Add(addMsg);


			//Inline function for adding properties to CustomData
			//Takes input value formatted as value=data,value2=data2 etc
			Dictionary<string, string> addProps(string addValues)
			{
				var addList = new Dictionary<string, string>();

				if (string.IsNullOrEmpty(addValues) || addValues.IndexOf("=") == -1)
					return addList;

				var addParams = addValues.Split(',');
				foreach (var p in addParams)
				{
					addList.Add(p.Split('=')[0], p.Split('=')[1]);
				}

				return addList;
			}

			restRequest.Messages = msgList.ToArray();

			var response = SmsFactory.SendSms(restRequest);

			// TODO:
			//Just print output to console. You should handle each message and it's status and returned parameters here.
			Console.WriteLine(JsonSerializer.SerializeToString(response));


		}


		/// <summary>
		/// Send simple test message using HTTP GET API
		/// </summary>
		/// <param name="customerId"></param>
		/// <param name="password"></param>
		/// <param name="destinationAddress"></param>
		/// <param name="message"></param>
		public static void SendSmsMessage(int customerId, string password, long destinationAddress, string message)
		{

			//Send 1.
			var result1 = SmsFactory.SendSms(new SmsHttpMessage
			{
				Category = "TEST-MESSAGES",
				CustomerId = customerId,
				CustomerPassword = password,
				DestinationAddress = destinationAddress,
				Expires = DateTime.Now.AddHours(1),
				GatewayNumber = 99700999,
				Price = 0,
				Qos = 3, //<- Set to 1 if sending password or something that needs to be delivered quickly
				MessageId = Guid.NewGuid().ToString().Replace("-", ""),
				MessageType = "11", //<- By specifying 11 the remote server will split message into concatenated if text exceeds 160 chars
				UserData = message,
				OriginatorAddress = "+4799700999"
			});

			// TODO:
			//Just print output to console. You should handle each message and it's status and returned parameters here.
			Console.WriteLine(JsonSerializer.SerializeToString(result1));

			//Print result:
			if (result1.Success)
			{
				//OK
			}
			else
			{
				//Failed
			}

		}

		/// <summary>
		/// Send Sms message using SOAP API
		/// </summary>
		/// <param name="customerId"></param>
		/// <param name="password"></param>
		/// <param name="destinationAddress"></param>
		/// <param name="message"></param>
		public static void SendSmsMessageSoap(int customerId, string password, long destinationAddress, string message)
		{

			//Send 1.
			var result1 = SmsFactory.SendSms(new SmsSoapApi.SendSMSRequest
			{
				Authorizer = new SmsSoapApi.Authorizer { CustomerID = customerId, Password = password },
				smsObj = new SmsSoapApi.SMSMessage
				{
					Category = "TEST-MESSAGES",
					CustomData = "qos=3",
					DeliveryReportUrl = string.Empty,
					DestinationAddress = destinationAddress.ToString(),
					Gateway = "99700999",
					MessageID = Guid.NewGuid().ToString().Replace("-", ""),
					MessageType = "11",
					OriginatorAddress = "+4799700999",
					Price = 0,
					ServiceCode = string.Empty,
					ServiceDescription = string.Empty,
					ValidationPeriod = DateTime.Now.AddHours(1).ToString("ddmmyyyyHHmmss"),
					UserDataHeader = string.Empty,
					UserData = message
				}

			});

			// TODO:
			//Just print output to console. You should handle each message and it's status and returned parameters here.
			Console.WriteLine(JsonSerializer.SerializeToString(result1));

			//Print result:
			if (result1.StatusCode == 0)
			{
				//OK
			}
			else
			{
				//Failed
			}


		}

		/// <summary>
		/// Test number agains International Numbering plan
		/// </summary>
		/// <param name="mobileNumber"></param>
		public static void NumberplanQuery(long mobileNumber)
		{
			var result = NumberplanFactory.CheckNumberplan(mobileNumber);

			//Print result
			Console.WriteLine(JsonSerializer.SerializeToString(result));
		}

		/// <summary>
		/// Check number against Norwegian mobile registry
		/// </summary>
		/// <param name="mobileNumber"></param>
		public static void NrdbQuery(long mobileNumber)
		{

			if (mobileNumber.ToString().Length < 10 && !mobileNumber.ToString().StartsWith("47"))
			{
				Console.WriteLine("Invalid Norwegian mobile number");
				return;
			}


			var result = NrdbFactory.CheckNrdb(mobileNumber);

			//Print result
			Console.WriteLine(JsonSerializer.SerializeToString(result));

		}

	}
}
