using System;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
{
    public class AdministratorDto :  BaseEntity
    {
        public string FullName {get; set; }
        public string UserName  {get; set; }
        public string  AdminEmail {get; set; }
        public int UserID {get; set; }
        public string Address {get; set; }
        public string AdminImage {get; set; }
        public Gender Gender {get; set; }
        public DateTime DateOfBirth {get; set; }
        public AdminType AdminCategory {get; set; }
         public string FirstName {get; set; }
        public string LAstName {get; set; }
        
        public string PhoneNumber {get; set; }


    }

    public class CreateAdminRequestModel
    {
        public string FirstName {get; set; }
        public string LAstName {get; set; }
        public string UserName { get; set; }
        public string AdminEamil {get; set; }
        public string Password {get; set; }
        public DateTime DateOfBirth {get;set; }
        public Gender Gender {get; set; }
        public string Address {get; set; }
        public IFormFile AdminImage {get; set; }
        public string PhoneNumber {get; set; }
          public AdminType AdminCategory {get; set; }

    }

    public class CreateSubAdminRequestModel 
    {
        
         public AdminType AdminCategory {get; set; }
        public string FirstName {get; set; }
        public string LAstName {get; set; }
        public string UserName { get; set; }
        public string AdminEamil {get; set; }
        public string Password {get; set; }
        public DateTime DateOfBirth {get;set; }
        public Gender Gender {get; set; }
        public string Address {get; set; }
        public IFormFile AdminImage {get; set; }
        public string PhoneNumber {get; set; }

    }

     public class UpdateAdminRequestModel
     {
         public string FirstName {get; set; }
         public string LastName {get; set; }
         public  string Email {get; set; }
         public string PassWord {get; set; }
         public IFormFile  AdminImage {get; set; }
         public string UserName {get; set; }
           public AdminType AdminCategory {get; set; }
         

     }
}