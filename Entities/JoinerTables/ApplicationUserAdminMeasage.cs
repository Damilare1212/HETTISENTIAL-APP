namespace HettisentialMvc
{
    public class ApplicationUserAdminMeasage : AuditableEntity
    {
          public int ApplicationUserId {get;set; }
        public Patient Patient {get;set; }
        public int AdminMessageId {get;set; }
        public AdminMeasage AdminMessage {get;set; }
    }
}