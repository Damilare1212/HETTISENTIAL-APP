using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
{
    public class HospitalDto : CreateAddressRequestModel 
    {
        public int Id {get; set; }
        public string HealthCenterName {get; set; }
        public string HealthCenterAddress {get; set; }
        public string HealthCenterImage {get; set; }
        public string HealthCenterPhoneNumber {get; set; }
        public string HEalthCenterEmail {get; set; }
         public string HoursOfWork {get; set; }
           public string Image{get; set;}
        public HospitalCategory HealthCenterCategory {get; set; }
        public ICollection<UserHealthCenterDTO> UserHealthCenterDto {get; set; }


        
        //   public string Name {get; set; }
        //   public string PhoneNumber  {get; set; }
        //   public string Email  {get; set; }
        //   public string HospitalImage  {get; set; }
        //  //  public Image image  {get ; set; }
        //  // public  string[] Images  {get ; set; }
        //       public IList<Image> images { get; set; }
        //  // public string Address  {get; set; } 
        //   public User User {get; set; }
        //   public int  userID {get; set; }
        //   public string HoursOfWork {get; set; }
        //    public  string HoursOfWorks  {get ; set; }  
        //      public Address address { get; set;  }
        //   //  public WeekDay weekDays  {get ; set; }
        //   public HospitalCategory HealthCenterCategory {get;set; }
        //  public ICollection<patienthospital> UserHealthCenters { get; set; } = new HashSet<patienthospital>();
        //  public List<HospitalService> hospitalServices {get; set; } = new List<HospitalService>();


       
    }

    public class CreateHospitalRequestModel : CreateAddressRequestModel 
    {
        public string HealthCenterName  {get; set; }
        public string HealthcenterAddress  {get; set; }
        public string HealthCenterPhoneNumber  {get; set; }
        public string HealthCenterEmail {get; set; }
        public IFormFile HealthCenterImage {get; set; }
          public HospitalCategory HealthCenterCategory {get; set; }
          public string HoursOfWork  {get; set; }
             public string Password  {get; set; }

              
      //  public string 
    }

    public class UpdateHospitalRequestModel : CreateAddressRequestModel 
    {
        
        public string HealthCenterName  {get; set; }
        public string HealthcenterAddress  {get; set; }
        public string HealthCenterPhoneNumber  {get; set; }
        public string HealthCenterEmail {get; set; }
          public string HoursOfWork  {get; set; }
        public IFormFile HealthCenterImage {get; set; }
          public HospitalCategory HealthCenterCategory {get; set; }
    }
}