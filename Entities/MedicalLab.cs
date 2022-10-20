using System;
using System.Collections.Generic;

namespace HettisentialMvc
{
    public class MedicalLab : AuditableEntity
    {
        
        public string LabName {get ; set; }
        public string Category {get; set; }
      //  public string Address {get ; set; }
        public string Email {get ; set; }
        public string PhoneNumber {get ; set; }
       //  public  string[] Images  {get ; set; }
       // public Image image  {get ; set; }
        public IList<Image> images { get; set; }
          public Address address  {get ; set; }
         public  string HoursOfWork  {get ; set; }  
      //  public List<string> ServicesOPions  {get ; set; } = new List<string>();
        public string WebsiteUrl  {get ; set; }
        public string Description  {get ; set; }
          public int UserId{get;set;}
        public User User{get;set;}
       //  public WeekDay weekDays  {get ; set; }
       
       public List<medicalLabService > medicalLabServices {get; set; } = new List<medicalLabService>();


          public string Image {get; set;}
         public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }

    }
}