using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InteleSmsMessagingKit
{
    //Full manual: https://kunde.intelesms.no/files/SMS_Gateway_Implementation_Guide.pdf

    public static class HowTo
    {

        public static void SendSmsMessage()
        {

            //Send 1.
            var result1 = SmsFactory.SendSms(new SmsHttpMessage
            {
                Category = "MyTestMessages",
                CustomerId = 0,
                CustomerPassword = "MySecret",
                DestinationAddress = 4712345678,
                Expires = DateTime.Now.AddHours(1),
                GatewayNumber = 99700999,
                Price = 0,
                Qos = 3, //<- Set to 1 if sending password or something that needs to be delivered quickly
                MessageId = Guid.NewGuid().ToString().Replace("-", ""),
                MessageType = "11", //<- By specifying 11 the remote server will split message into concatenated if text exceeds 160 chars
                UserData = "This is a test message"
            });
            
            //Print result:
            if (result1.Success)
            {
                //OK
            } else
            {
                //Failed
            }

            //Send 2.

            var result2 = SmsFactory.SendSmsWithParameters(0, "MySecret", 99700999, 0, Guid.NewGuid().ToString().Replace("-", ""),
                4712345678, "MyNumber", "This is a test message", "MyTestMessages", "", 3, "11", "", "");

            //Print result
            if (result2.Success)
            {
                //OK
            } else
            {
                //Failed
            }

        }

        public static void NumberplanQuery()
        {
            var result = NumberplanFactory.CheckNumberplan(4712345678);

            //Print result
        }

        public static void NrdbQuery()
        {
            var result = NrdbFactory.CheckNrdb(471234567);

            //Print result

        }

    }
}
