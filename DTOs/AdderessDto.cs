
namespace HettisentialMvc
{
    public class AddressDTo : BaseEntity
    {
        public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }
        public Pharmacy Pharmacy {get; set; }
        public Hospital hospital {get; set; }
        public HealthCenter healthCenter {get; set; }
        public MedicalLab medicalLab {get; set; }
    }

    public class CreateAddressRequestModel
    {
          public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }
    }

      public class UpdateAddressRequestModel
      {
         
          public string Country  {get; set; }
        public string StreetAddress  {get; set; }
        public string LocalGovernmentArea  {get; set; }
        public string City  {get; set; }
        public int PostalCode  {get; set; }
        public string State  {get; set; }
      }
}