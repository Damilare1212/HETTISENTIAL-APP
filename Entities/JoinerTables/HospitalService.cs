

using System;
namespace HettisentialMvc
{
    public class HospitalService : AuditableEntity
    {
         public int HospitalID {get; set; }
         public int ServicesID {get; set; }
         public Services services {get; set; }
         public Hospital Hospital {get; set; }
    }
}