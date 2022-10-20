using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
{
    public class PatientDto : BaseEntity
    {
        public string Fullname {get; set; }
        public string UserName {get; set; }
        public string Email {get ;set; }
        public string Image {get; set; }
        public Gender Gender {get; set; }
         public string Address {get; set; }
        public DateTime DateOfBirth {get; set; }
         public ICollection<ApplicationUSerAdminMeasageDTO> ApplicationUserAdminMessages {get; set; } = new List<ApplicationUSerAdminMeasageDTO>();
        public ICollection<UserHealthCenterDTO> UserHealthCenterDto {get; set; }
        
    }

      public class  CreatePatientRequestModel
      {
          public string FirstName {get; set; }
          public string LastName {get; set; }
          public string Email  {get; set; }
          public IFormFile Image  {get; set; }
          public Gender Gender  {get; set; }
          public string  UserName  {get; set; }
          public string Password  {get; set; }
          public DateTime DateOfbirth  {get; set; }
          public string Phonenumber {get; set; }
          public string Adderess {get; set; }


      }

      public class UpdatePatientRequestModel
      {
          public string FirstName  {get; set; }
          public string LastName  {get; set; }
          public string PassWord  {get; set; }
          public IFormFile Image  {get; set; }
           public string Email  {get; set; }
          public string UserName  {get; set; }
          
      }
}