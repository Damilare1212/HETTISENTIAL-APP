using System.Threading.Tasks;
namespace HettisentialMvc.MailClass
{
    public interface IEmail
    {
      
        public void SendEmaiL(EmailDto email);
    }
}