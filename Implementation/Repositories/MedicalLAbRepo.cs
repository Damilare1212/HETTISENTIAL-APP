using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class mMedicalLAbRepo : IMedicalLabRepo
    {
        private readonly ApplicationContext _Context;
       public mMedicalLAbRepo (ApplicationContext context)
        {
            _Context = context;
        }

        public MedicalLabDTo Create(MedicalLab medicalLab)
        {
           _Context.medicalLabs.Add(medicalLab);
            _Context.SaveChanges();
            return  new MedicalLabDTo
            {
                  
                    LabName  = medicalLab.LabName,
                    Category = medicalLab.Category,
                    Email = medicalLab.Email,
                    PhoneNumber = medicalLab.PhoneNumber,
                    WebsiteUrl = medicalLab.WebsiteUrl,
                    Description = medicalLab.Description,
                 
                    medicalLabServices = medicalLab.medicalLabServices,
                    HoursOfWork = medicalLab.HoursOfWork,
                    Images = (ICollection<ImageDTO>)medicalLab.images,
                    UserId = (int)medicalLab.UserId,
                    LabImage = medicalLab.Image,


                     Country = medicalLab.Country,
                  LocalGovernmentArea = medicalLab.LocalGovernmentArea,
                  PostalCode = medicalLab.PostalCode,
                  City = medicalLab.City,
                  StreetAddress = medicalLab.StreetAddress,
                  State = medicalLab.State,

            };
        }

        public bool DeleTe(MedicalLab medicalLab)
        {
            _Context.medicalLabs.Remove(medicalLab);
           _Context.SaveChanges();
           return true;
        }

        public bool ExistByEmail(string email)
        {
             var mail = _Context.medicalLabs.Any(e => e.Email == email);
           return mail;
        }

        public bool ExistById(int id)
        {
            var ID =  _Context.medicalLabs.Any(e => e.Id == id);
            return ID;
        }

        public MedicalLab get(int Id)
        {
           return _Context.medicalLabs
            .FirstOrDefault(d => d.Id 
            == Id);
        }

        public List<MedicalLabDTo> GetAllMedicalLab()
        {
             return _Context.medicalLabs.Select(phar => new MedicalLabDTo
            {
               
                    

                Id = phar.Id,
                  Country = phar.Country,
                  LocalGovernmentArea = phar.LocalGovernmentArea,
                  PostalCode = phar.PostalCode,
                  City = phar.City,
                  StreetAddress = phar.StreetAddress,
                  State = phar.State,
                  LabImage = phar.Image,

                LabName = phar.LabName,
                Category = phar.Category,
                HoursOfWork = phar.HoursOfWork,
                medicalLabServices = phar.medicalLabServices,
                Email = phar.Email,
                WebsiteUrl = phar.WebsiteUrl,
                Description = phar.Description,
              
                PhoneNumber = phar.PhoneNumber ,
            }).ToList();
        }

        public MedicalLab GetMedicalLabByLGA(string LGA)
        {
            return (MedicalLab)_Context.medicalLabs.Include(x => x.State)
            .Where(x => x.address.LocalGovernmentArea.ToUpper() == LGA.ToUpper());
        }

        public IList<MedicalLab> GetMedicalLabByState(string State)
        {
            return   _Context.medicalLabs.Include(x => x.Country)
            .Where(x => x.address.State.ToUpper() == State.ToUpper())
            .ToList();
        }

        public MedicalLab GetPharmacyInfo(int Id)
        {
             var PHARM =   _Context.medicalLabs
            .Include(x => x.address)
            .Include(a => a.images)
            .Include(b => b.LabName)
            .Include(b => b.HoursOfWork)
            .Include(c => c.Category).SingleOrDefault(e => e.Id == Id);
            return PHARM;
        }

        public MedicalLabDTo ReturnById(int Id)
        {
           var pharmacy = _Context.medicalLabs.SingleOrDefault(x => x.Id == Id);
            return new MedicalLabDTo
            {
                LabName = pharmacy.LabName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                    LabImage = pharmacy.Image,
                    medicalLabServices = pharmacy.medicalLabServices,
                    HoursOfWork = pharmacy.HoursOfWork,
                    Images = (ICollection<ImageDTO>)pharmacy.images,
                    UserId = (int)pharmacy.UserId,
                       Country = pharmacy.Country,
                  LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                  PostalCode = pharmacy.PostalCode,
                  City = pharmacy.City,
                  StreetAddress = pharmacy.StreetAddress,
                  State = pharmacy.State,

            };
        }

        public MedicalLab Update(MedicalLab medicalLab)
        {
            _Context.medicalLabs.Update(medicalLab);
            _Context.SaveChanges();
            return medicalLab;
        }
    }
}