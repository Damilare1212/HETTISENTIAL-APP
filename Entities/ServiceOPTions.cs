

using System.Collections.Generic;
namespace HettisentialMvc
{
    public class Services:AuditableEntity{
        public string ServiceName {get; set; }
        public string Description {get; set; }

        public List<PharmacyService> pharmacyServices  {get; set; } = new  List<PharmacyService>();
       public List<HealthCenterService> healthCenterServices  {get; set; } = new  List<HealthCenterService>();
       public List<HospitalService> hospitalServices {get; set; } = new List<HospitalService>();
       public List<medicalLabService > medicalLabServices {get; set; } = new List<medicalLabService>();


    }
}