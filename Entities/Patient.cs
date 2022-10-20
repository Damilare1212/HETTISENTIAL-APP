using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
{
    public class Patient : AuditableEntity
    {
         public string Firstname {get; set; }
        public string Lastname {get; set; }
        public int Age {get; set; } 
        public DateTime DateOfBirth {get; set; }
        public string PhoneNumber {get; set; }
        public string Email {get; set; }
        public string Address {get; set; }
        public string UserImage {get; set; }
        public Gender gender {get; set; }
        public int UserId {get; set; }
         public User User {get; set; }
          // public string Image{get; set;}
           public ICollection<patienthospital> UserHealthCenters { get; set; } = new HashSet<patienthospital>();
      

        

    }
}