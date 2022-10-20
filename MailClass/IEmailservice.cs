using System.Threading.Tasks;
namespace HettisentialMvc.MailClass
{
    public interface IEmailService
    {
        void SendEmail(EmailDto email);
      //  public Task<bool> SendEmaiL(EmailDto email);
    }
}