using System;

namespace HettisentialMvc
{
    public class Address : AuditableEntity
    {
        public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }
        public int PharmacyID  {get; set; }
         public int hospitalID  {get; set; }
          public int healthCenterID  {get; set; }
           public int medicalLabID  {get; set; }
        public Pharmacy Pharmacy {get; set; }
        public Hospital hospital {get; set; }
        public HealthCenter healthCenter {get; set; }
        public MedicalLab medicalLab {get; set; }

    }
}