namespace HettisentialMvc
{
    public class MeasaageDto : BaseEntity
    {
        public string MessageContent {get; set; }
        public MessageType MessageType {get; set; }
        public string MessageSubject {get; set; }
     }
      
      public class CreateMessageRequestModel
      {
        public string MessageContent {get; set; }
        public MessageType MessageType {get; set; }
        public string MessageSubject {get; set; }
      }
     public class UpdateMessageRequestModel
     {
         public string MessageContent {get; set; }
          public MessageType MessageType {get; set; }
     }
}