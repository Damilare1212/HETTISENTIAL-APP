



using System;
namespace HettisentialMvc
{
    public class PharmacyService : AuditableEntity
    {
         public int PharmacyID {get; set; }
         public int ServicesID {get; set; }
         public Services services {get; set; }
         public Pharmacy Pharmacy {get; set; }
    }
}