using System;
using System.Collections.Generic;
using HettisentialMvc.Entities;
using HettisentialMvc.Entities.JoinerTables;

namespace HettisentialMvc
{
    public class User : AuditableEntity
    {
        public string Email {get; set; }
        public string Password {get; set; } 
        public string PhoneNumber {get; set; }
        public string UserFirstName {get; set; } 
        public string UserLastName {get; set; }
        public string UserName {get; set; }
       
       
          public Administrator Administrator { get; set; }
          public Patient patient {get; set; }
          public Hospital Hospital {get; set; }
          public HealthCenter healthCenter {get; set; }
          public Pharmacy pharmacy {get; set; }
          public MedicalLab medicalLab {get; set; }
          
        public ICollection<UserRole> UserRoles{get;set;} = new List<UserRole>();
 
        

    }
}