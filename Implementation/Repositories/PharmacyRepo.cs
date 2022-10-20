
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace HettisentialMvc
{
    public class PharmacyRepo : IPharmacyRepo
    {
        private readonly ApplicationContext  _Context;
        public PharmacyRepo (ApplicationContext context)
        {
            _Context = context;
        }

        public PharmacyDTo Create(Pharmacy pharmacy)
        {
            _Context.pharmacies.Add(pharmacy);
            _Context.SaveChanges();
            return  new PharmacyDTo
            {
                  
                    PharmacyName = pharmacy.PharmacyName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                   // address = pharmacy.address,
                    pharmacyServices = pharmacy.pharmacyServices,
                    HoursOfWork = pharmacy.HoursOfWork,
                    Images = (ICollection<ImageDTO>)pharmacy.images,
                    UserId = (int)pharmacy.UserId,
                    PharmacyImage = pharmacy.Image,


                     Country = pharmacy.Country,
                  LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                  PostalCode = pharmacy.PostalCode,
                  City = pharmacy.City,
                  StreetAddress = pharmacy.StreetAddress,
                  State = pharmacy.State,



            };
        }

        public bool DeleTe(Pharmacy pharmacy)
        {
            _Context.pharmacies.Remove(pharmacy);
           _Context.SaveChanges();
           return true;
        }

        public bool ExistByEmail(string email)
        {
             var mail = _Context.pharmacies.Any(e => e.Email == email);
           return mail;
        }

        public bool ExistById(int id)
        {
             var ID =  _Context.pharmacies.Any(e => e.Id == id);
            return ID;
        }

        public Pharmacy get(int Id)
        {
            return _Context.pharmacies
            .FirstOrDefault(d => d.Id 
            == Id);
        }

        public List<PharmacyDTo> GetAllPharmacy()
        {
            return _Context.pharmacies.Select(phar => new PharmacyDTo
            {
               
                    

                Id = phar.Id,
                  Country = phar.Country,
                  LocalGovernmentArea = phar.LocalGovernmentArea,
                  PostalCode = phar.PostalCode,
                  City = phar.City,
                  StreetAddress = phar.StreetAddress,
                  State = phar.State,
                  PharmacyImage = phar.Image,

                PharmacyName = phar.PharmacyName,
                Category = phar.Category,
                HoursOfWork = phar.HoursOfWork,
                pharmacyServices = phar.pharmacyServices,
                Email = phar.Email,
                WebsiteUrl = phar.WebsiteUrl,
                Description = phar.Description,
            
              
                PhoneNumber = phar.PhoneNumber ,
            }).ToList();
        }

        public Pharmacy GetPharmacyByLGA(string LGA)
        {
            return (Pharmacy)_Context.pharmacies.Include(x => x.State)
            .Where(x => x.address.LocalGovernmentArea.ToUpper() == LGA.ToUpper());
            //.ToList();
            // (Pharmacy)phar;
        }

        public IList<Pharmacy> GetPharmacyByState(string State)
        {
             return   _Context.pharmacies.Include(x => x.Country)
            .Where(x => x.address.State.ToUpper() == State.ToUpper())
            .ToList();
           
        }

        public Pharmacy GetPharmacyInfo(int Id)
        {
             var PHARM =   _Context.pharmacies
            .Include(x => x.address)
            .Include(a => a.images)
            .Include(b => b.PharmacyName)
            .Include(b => b.HoursOfWork)
            .Include(c => c.Category).SingleOrDefault(e => e.Id == Id);
            return PHARM;
        }

        public PharmacyDTo ReturnById(int Id)
        {
             var pharmacy = _Context.pharmacies.SingleOrDefault(x => x.Id == Id);
            return new PharmacyDTo
            {
                PharmacyName = pharmacy.PharmacyName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                  //  address = pharmacy.address,
                    pharmacyServices = pharmacy.pharmacyServices,
                    HoursOfWork = pharmacy.HoursOfWork,
                    Images = (ICollection<ImageDTO>)pharmacy.images,
                    UserId = (int)pharmacy.UserId,
                       Country = pharmacy.Country,
                  LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                  PostalCode = pharmacy.PostalCode,
                  City = pharmacy.City,
                  StreetAddress = pharmacy.StreetAddress,
                  State = pharmacy.State,
                  PharmacyImage = pharmacy.Image,

            };
        }

        public Pharmacy Update(Pharmacy pharmacy)
        {
             _Context.pharmacies.Update(pharmacy);
            _Context.SaveChanges();
            return pharmacy;
        }
    }
}