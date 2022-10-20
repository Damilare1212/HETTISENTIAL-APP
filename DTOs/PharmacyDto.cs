
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
 {
    public class PharmacyDTo : CreateAddressRequestModel 
    {
        public int Id {get; set; }
            public string PharmacyName {get ; set; }
        public string Category {get; set; }
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
         public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
        public  string HoursOfWork  {get ; set; } 
        public List<PharmacyService> pharmacyServices  {get; set; } = new  List<PharmacyService>();
        public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
     
          public int UserId{get;set;}
           public string PharmacyImage {get; set;}
          
        public User User{get;set;}
      


    }

    public class CreatePharmacyRequestsmodel : CreateAddressRequestModel
    {
         public string PharmacyName {get ; set; }
        public string Category {get; set; }
           public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
         public ICollection<string> Images {get; set; } = new HashSet<string>();
         public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
       public IFormFile PharmacyImage {get; set; }
   //   public string Image {get; set;}
          // public IFormFile Image{get; set;}

          public int UserId{get;set;}
         
        public  string HoursOfWork  {get ; set; } 
         // public IFormFile Image {get; set; }
        public List<PharmacyService> pharmacyServices  {get; set; } = new  List<PharmacyService>();
       
    }

     public class UpdatePharmacyRequestsmodel : CreateAddressRequestModel
     {
            public string PharmacyName {get ; set; }
        public string Category {get; set; }
           public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
        public ICollection<string> Images {get; set; } = new HashSet<string>();
         public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
           public IFormFile PharmacyImage{get; set;}
       
          // public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
        public  string HoursOfWork  {get ; set; } 
        public List<PharmacyService> pharmacyServices  {get; set; } = new  List<PharmacyService>();
     }
 }