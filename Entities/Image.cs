

using System.Collections.Generic;
namespace HettisentialMvc
{
    public class Image : AuditableEntity
    {
        public string ImagePath { get; set; }
          public string Description { get; set; }

            // public List<Pharmacy> Pharmacies { get; set; }
            // public List<Hospital> hospitals { get; set; }
            // public List<HealthCenter> healthCenters { get; set; }
            // public List<MedicalLab> medicalLabs { get; set; }
          public int PharmacyID  {get; set; }
         public int hospitalID  {get; set; }
          public int healthCenterID  {get; set; }
           public int medicalLabID  {get; set; }
            public Pharmacy Pharmacy { get; set; }
            public Hospital hospital { get; set; }
            public HealthCenter healthCenter { get; set; }
            public MedicalLab medicalLab { get; set; }

        
    }
}