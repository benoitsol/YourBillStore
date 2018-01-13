using System.Threading.Tasks;

namespace Services.BusinessServices.Interface
{
    public interface IMessagingService
    {
        Task<SmsMessageStatus> SendSmsToPhone(string MobileNO, string MSG);
    }
}
