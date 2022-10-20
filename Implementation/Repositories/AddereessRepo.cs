


using System.Collections.Generic;
using System.Linq;

namespace HettisentialMvc
{
    public class AddressRepo : IAddressRepo
    {

           private readonly ApplicationContext _context;
        public AddressRepo (ApplicationContext context)
        {
            _context = context;
        }

        public AddressDTo Create(Address address)
        {
 

           _context.Addresses.Add(address);
           _context.SaveChanges();
           return new AddressDTo{
            Id = address.Id,
              Country = address.Country,
              StreetAddress =  address.StreetAddress,
              LocalGovernmentArea =  address.LocalGovernmentArea,
              City = address.City,
              PostalCode = address.PostalCode,
              Pharmacy = address.Pharmacy,
              State = address.State,
              hospital = address.hospital,
              healthCenter = address.healthCenter,
              medicalLab = address.medicalLab,
              

           };
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
            var exist = _context.Addresses.Any(e => e.Id == id);
            return exist;
        }

        public List<AddressDTo> GetAllAddress()
        {
          return _context.Addresses.Select(address => new AddressDTo
          {
               Id = address.Id,
              Country = address.Country,
              StreetAddress =  address.StreetAddress,
              LocalGovernmentArea =  address.LocalGovernmentArea,
              City = address.City,
              PostalCode = address.PostalCode,
              Pharmacy = address.Pharmacy,
              State = address.State,
              hospital = address.hospital,
              healthCenter = address.healthCenter,
              medicalLab = address.medicalLab,
          }).ToList();
        }

        public Address GetById(int id)
        {
            var get =  _context.Addresses.Where(s => s.Id == id );
            return (Address)get;

        }

        public AddressDTo ReturnById(int id)
        {
             var aderess = _context.Addresses.FirstOrDefault
             (a => a.Id == id);
            return new AddressDTo
            {
                //            public string Country  {get; set; }
                // public string StreetAddress  {get; set; }
                // public string LocalGovernmentArea  {get; set; }
                // public string City  {get; set; }
                // public int PostalCode  {get; set; }
                // public string State  {get; set; }
                // public Pharmacy Pharmacy {get; set; }
                // public Hospital hospital {get; set; }
                // public HealthCenter healthCenter {get; set; }
                // public MedicalLab medicalLab {get; set; }

                 Id = aderess.Id,
                 Country = aderess.Country,
                 StreetAddress = aderess.StreetAddress,
                 State = aderess.State,
                 LocalGovernmentArea = aderess.LocalGovernmentArea,
                 City = aderess.City,
                 PostalCode = aderess.PostalCode,
                 Pharmacy = aderess.Pharmacy,
                 hospital =aderess.hospital,
                 healthCenter = aderess.healthCenter,
                 medicalLab = aderess.medicalLab,

               
            };
        }

        public Address Update(Address address)
        {
          _context.Addresses.Update(address);
          _context.SaveChanges();
          return address;
        }
    }
}