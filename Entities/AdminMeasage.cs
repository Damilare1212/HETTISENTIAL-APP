using System;
using System.Collections.Generic;

namespace HettisentialMvc
{
    public class AdminMeasage : AuditableEntity
    {
        
        public string MessageContent{get;set;}
       
        public string MessageSubject{get;set;}
        public DateTime DateSent{get;set;}
         public MessageType MesageType{get;set;}
        public ICollection<ApplicationUserAdminMeasage> ApplicationUserAdminMessages{get;set;}
    }
}