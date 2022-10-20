

using System;
namespace HettisentialMvc
{
    public class HealthCenterService : AuditableEntity
    {
         public int HealthCenterID {get; set; }
         public int ServicesID {get; set; }
         public Services services {get; set; }
         public HealthCenter healthCenter {get; set; }
    }
}