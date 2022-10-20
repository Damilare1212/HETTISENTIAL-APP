namespace HettisentialMvc.MailClass
{
    public class EmailDto
    {
        public string ReceiverName{get; set;}
        public string ReceiverEmail{get; set;}
        public string Message{get; set;}
        public string Subject{get; set;}
    }

    public class EmailResponseModel
    {
        public string Measage {get; set; }
    }
}