using System.Collections.Generic;

namespace HettisentialMvc.Interface
{
    public interface Imeasagesender
    {
         string SendMailToMultipleUser( string Subject,List<string> userEmails, string message);
        string SendMailToSingleUser( string Subject, string userEmail, string message);
    }
}