namespace HettisentialMvc
{
    public class Measage : AuditableEntity
    {
        
        public string MessageContent{get;set;}
        public string MessageSubject{get;set;}
        public MessageType MesageType{get;set;}
       //  public User User {get; set; }
    }
}