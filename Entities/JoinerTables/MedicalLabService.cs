

using System;
namespace HettisentialMvc
{
    public class medicalLabService : AuditableEntity
    {
         public int medicalLabID {get; set; }
         public int ServicesID {get; set; }
         public Services services {get; set; }
         public MedicalLab medicalLab {get; set; }
    }
}