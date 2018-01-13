using DataService.Implementation;
using Microsoft.Extensions.Configuration;
using Services.BusinessServices.Interface;
using System.Threading.Tasks;

namespace Services.BusinessServices
{
    public class OTPService
    {
        private readonly OtpDataService otpDataService;
        private readonly IMessagingService smsService;
        private readonly string messageTemplate;

        public OTPService(IConfiguration configuration)
        {
            this.smsService = new MessagingService(configuration["SmsService:userName"], configuration["SmsService:password"]);
            this.otpDataService = new OtpDataService(configuration["ConnectionStrings:paybillstore_AzureStorageConnectionString"]);
            messageTemplate = configuration["SmsService:OTPMessageTemplate"];
        }

        public async Task<bool> RequestOtp(string phoneNumber)
        {
            var oneTimePassword = await otpDataService.RequestOtp(phoneNumber);
            var message = string.Format(messageTemplate, oneTimePassword);

            var response = await smsService.SendSmsToPhone(phoneNumber, message);
            return response == SmsMessageStatus.Success;            
        }

        public async Task<bool> validateUser(string phoneNumber, string oneTimePassword)
        {
            return await otpDataService.ValidateUserOtp(phoneNumber, oneTimePassword);
        }
    }
}
