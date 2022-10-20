using System;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc.Entities
{
    public class Administrator : AuditableEntity
    {
         public string Firstname {get; set; }
        public string Lastname {get; set; }
        public string UserName {get; set; }
        public string Email {get; set; }
        public DateTime DateOfBirth {get; set; }
        public string AdminImage {get; set; }
        public string PhoneNumber {get; set; }
        public Gender Gender {get; set; }
       public string Address {get; set; }
       public int UserId{get;set;}
        public User User{get;set;}
       // public int Age {get;set;}
        public AdminType AdministratorType{get;set;}
    }
}