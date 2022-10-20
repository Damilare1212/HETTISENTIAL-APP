using System.Collections.Generic;
using System;

namespace HettisentialMvc
{
    public   class Pharmacy : AuditableEntity
    {
        public string PharmacyName {get ; set; }
        public string Category {get; set; }

       
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
     
         public  string HoursOfWork  {get ; set; } 
      
        public string WebsiteUrl  {get ; set; }
        
        public string Description  {get ; set; }
        public Address address  {get ; set; }
           public int UserId{get;set;}
        public User User{get;set;}
        public IList<Image> images { get; set; }
          public string Image { get; set;}
       





         public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }
        public List<PharmacyService> pharmacyServices  {get; set; } = new  List<PharmacyService>();







        
      

    }
}