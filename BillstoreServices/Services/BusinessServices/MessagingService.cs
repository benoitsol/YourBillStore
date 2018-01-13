using Services.BusinessServices.Interface;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessServices
{
    public class MessagingService : IMessagingService
    {
        private readonly string smsServiceUserName;
        private readonly string smsServicePassword;

        public MessagingService(string userName, string password)
        {
            this.smsServiceUserName = userName;
            this.smsServicePassword = password;
        }
        public async Task<SmsMessageStatus> SendSmsToPhone(string MobileNO, string MSG)
        {
            string result = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nettyhost.com/smsapi/TR/sendmsg.aspx?&username="+ smsServiceUserName + "&password="+ smsServicePassword + "&mobile=" + MobileNO + "&sendername=TESTSN&message=" + MSG);

                var responseresult = await request.GetResponseAsync();

                var response = (HttpWebResponse) responseresult;
                Stream responseStream = response.GetResponseStream();

                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);

                result = readStream.ReadToEnd();
            }
            //catch (HttpException ex)
            //{
            //    result = "HTTP Error: " + ex.ToString();
           // }
            catch (Exception ex)
            {
                return SmsMessageStatus.Error;
            }

            //return "100 - Msg successfully sent.";
            return SmsMessageStatus.Success;
        }
    }

    public enum SmsMessageStatus
    {
        Success,
        Error,
        HttpError
    }
}


