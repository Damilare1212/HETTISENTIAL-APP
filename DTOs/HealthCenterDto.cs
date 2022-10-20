

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Utilities.Collections;

namespace HettisentialMvc
{
    public class HealthCenterDto : CreateAddressRequestModel 
    {
        public int Id {get; set; }
          public string HealthCenterName {get ; set; }
        public string Category {get; set; }
       
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
     
      public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
        public  string HoursOfWork  {get ; set; }  
         public List<HealthCenterService> healthCenterServices  {get; set; } = new  List<HealthCenterService>();
        public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
        public Address address { get; set;  }
          public int UserId{get;set;}
             public string IHealthCenterImage {get; set;}
        public User User{get;set;}
         public WeekDay weekDays  {get ; set; }
    }




    public class  CreateHealthCenterRequestModel : CreateAddressRequestModel 
    {
           public string HealthCenterName {get ; set; }
        public string Category {get; set; }
       
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
         public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
           public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
        public Address address { get; set;  }
        public User User{get;set;}
       //  public WeekDay weekDays  {get ; set; }
         public  string HoursOfWork  {get ; set; }  

           public IFormFile IHealthCenterImage {get; set;}
         public List<HealthCenterService> healthCenterServices  {get; set; } = new  List<HealthCenterService>();
    }










    public class  UpdateHealthCenterRequestModel : CreateAddressRequestModel 
    {
           public string HealthCenterName {get ; set; }
            public string WebsiteUrl  {get ; set; }
        public string Category {get; set; }
       
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
        public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
          
        public string Description  {get ; set; }
          public IFormFile IHealthCenterImage {get; set;}
        public Address address { get; set;  }
       
        // public WeekDay weekDays  {get ; set; }

         public  string HoursOfWork  {get ; set; }  
         public List<HealthCenterService> healthCenterServices  {get; set; } = new  List<HealthCenterService>();
    }
}