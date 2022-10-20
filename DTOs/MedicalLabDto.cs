

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HettisentialMvc
{
    public class MedicalLabDTo : CreateAddressRequestModel 
    {
        public int Id {get; set; }
           public string LabName {get ; set; }
        public string Category {get; set; }      
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
         public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
        public  string HoursOfWork  {get ; set; }  
       public List<medicalLabService > medicalLabServices {get; set; } = new List<medicalLabService>();

        public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
          public int UserId{get;set;}
        public User User{get;set;}
           public string LabImage {get; set;}

         public Address address  {get ; set; }
        //  public WeekDay weekDays  {get ; set; }









         
            //     public string LabName {get ; set; }
            //     public string Category {get; set; }
            //   //  public string Address {get ; set; }
            //     public string Email {get ; set; }
            //     public string PhoneNumber {get ; set; }
            //    //  public  string[] Images  {get ; set; }
            //    // public Image image  {get ; set; }
            //     public IList<Image> images { get; set; }
            //       public Address address  {get ; set; }
            //     
            //   //  public List<string> ServicesOPions  {get ; set; } = new List<string>();
            //     public string WebsiteUrl  {get ; set; }
            //     public string Description  {get ; set; }
            //       public int UserId{get;set;}
            //     public User User{get;set;}
            //    //  public WeekDay weekDays  {get ; set; }
            
            //    public List<medicalLabService > medicalLabServices {get; set; } = new List<medicalLabService>();









    }

    public class CreateMedicalLabRequestModel : CreateAddressRequestModel 
    {
        
           public string LabName {get ; set; }
        public string Category {get; set; }
      
        public string Email {get ; set; }
        
        public string PhoneNumber {get ; set; }
          public IFormFile LabImage {get; set;}
         public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
          public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
          public int UserId{get;set;}
          // public WeekDay weekDays  {get ; set; }
            public  string HoursOfWork  {get ; set; }  
          
       public List<medicalLabService > medicalLabServices {get; set; } = new List<medicalLabService>();
    }

    
     public class UpdateMedicalLabRequestModel : CreateAddressRequestModel 
     {
          public string LabName {get ; set; }
        public string Category {get; set; }
      
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
          public IFormFile LabImage{get; set;}
         public ICollection<ImageDTO> Images {get; set; } = new HashSet<ImageDTO>();
       
        public string Description  {get ; set; }
          
          // public WeekDay weekDays  {get ; set; }
            public  string HoursOfWork  {get ; set; }  

              public string WebsiteUrl  {get ; set; }
       public List<medicalLabService > medicalLabServices {get; set; } = new List<medicalLabService>();
     }
}