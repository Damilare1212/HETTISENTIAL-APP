using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
{
    public class Hospital : AuditableEntity
    {
       // public int Id {get; set; }
        public string Name {get; set; }
        public string PhoneNumber  {get; set; }
        public string Email  {get; set; }
        public string HospitalImage  {get; set; }
       
            public IList<Image> images { get; set; }
      
        public User User {get; set; }
        public int  userID {get; set; }
        public string HoursOfWork {get; set; }
         public  string HoursOfWorks  {get ; set; }  
           public Address address { get; set;  }
        //  public WeekDay weekDays  {get ; set; }
        public HospitalCategory HealthCenterCategory {get;set; }
       public ICollection<patienthospital> UserHealthCenters { get; set; } = new HashSet<patienthospital>();
       public List<HospitalService> hospitalServices {get; set; } = new List<HospitalService>();
          public string Image{get; set;}
         public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }




          


                
     
       
        
        
        
     
        
        // public List<string> ServicesOPions  {get ; set; } = new List<string>();
        // public string WebsiteUrl  {get ; set; }
        // public string Description  {get ; set; }



       
        //  public bool IsDeleted { get; set; } 
        // public DateTime Created { get; set; }
        // public DateTime? Modified { get; set; }
        // public string CreatedBy { get; set; }
        // public string ModifiedBy { get; set; }
    }
}