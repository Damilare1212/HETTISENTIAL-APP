using System;
using System.Collections.Generic;

namespace HettisentialMvc
{
    public class AdminMeassageDTO : BaseEntity
    {
        public string MeasageContent {get; set; }
        public MessageType MessageType {get; set; }
        public string MessageSubject {get; set; }
        public DateTime DateSent {get; set; }
        public ICollection<ApplicationUSerAdminMeasageDTO> ApplicationUSerAdminMeasageDTOs {get; set; }

        // public static implicit operator AdminMeassageDTO(List<AdminMeassageDTO> v)
        // {
        //     throw new NotImplementedException();
        // }
    }
     public class CreateAdminMessageRequestModel
     {
         public MessageType MeasageType {get; set; }
         public string MeasageSubject {get; set; }
       //  public string MessageContent {get; set; }
     }

     public class UpdateAdminMeasageRequestModel
     {
           public MessageType MeasageType {get; set; }
            public string MeasageSubject {get; set; }
            public DateTime DateSent {get; set; }
     }
}