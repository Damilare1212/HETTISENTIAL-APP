

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
     public class HealthCenerRepo : IHealthCenteRRepo
     {
             private readonly ApplicationContext  _Context;
        public HealthCenerRepo (ApplicationContext context)
        {
            _Context = context;
        }

        public HealthCenterDto Create(HealthCenter healthCenter)
        {
            _Context.healthCenters.Add(healthCenter);
            _Context.SaveChanges();
            return new HealthCenterDto
            {
                 

                HealthCenterName = healthCenter.HealthCenterName,
                Category = healthCenter.Category,
                Email = healthCenter.Email,
                
                PhoneNumber = healthCenter.PhoneNumber,
                HoursOfWork = healthCenter.HoursOfWork,
                Description = healthCenter.Description,
                WebsiteUrl = healthCenter.WebsiteUrl,
                IHealthCenterImage = healthCenter.Image,
                UserId = healthCenter.UserId,

                  Country = healthCenter.Country,
                  LocalGovernmentArea = healthCenter.LocalGovernmentArea,
                  PostalCode = healthCenter.PostalCode,
                  City = healthCenter.City,
                  StreetAddress = healthCenter.StreetAddress,
                  State = healthCenter.State,


                

            };
        }

        public bool DeleTe(HealthCenter pharmacy)
        {
           _Context.healthCenters.Remove(pharmacy);
           _Context.SaveChanges();
           return true;
        }

        public bool ExistByEmail(string email)
        {
           var mail = _Context.healthCenters.Any(e => e.Email == email);
           return mail;
        }

        public bool ExistById(int id)
        {
           
             var ID =  _Context.healthCenters.Any(e => e.Id == id);
            return ID;
        }

        public HealthCenter get(int Id)
        {
            return _Context.healthCenters
            .FirstOrDefault(d => d.Id 
            == Id);
        }

        public List<HealthCenterDto> GetAllHealthCener()
        {
            return _Context.healthCenters.Select(phar => new HealthCenterDto
            {
               
                    

                Id = phar.Id,
                  Country = phar.Country,
                  LocalGovernmentArea = phar.LocalGovernmentArea,
                  PostalCode = phar.PostalCode,
                  City = phar.City,
                  StreetAddress = phar.StreetAddress,
                  State = phar.State,

                HealthCenterName = phar.HealthCenterName,
                Category = phar.Category,
                HoursOfWork = phar.HoursOfWork,
                healthCenterServices = phar.healthCenterServices,
                Email = phar.Email,
                WebsiteUrl = phar.WebsiteUrl,
                IHealthCenterImage = phar.Image,
                Description = phar.Description,
              
                PhoneNumber = phar.PhoneNumber ,
            }).ToList();
        }

        public HealthCenter GetHealthCenterByLGA(string LGA)
        {
           
            return (HealthCenter)_Context.healthCenters.Include(x => x.State)
            .Where(x => x.address.LocalGovernmentArea.ToUpper() == LGA.ToUpper());
        }

        public IList<HealthCenter> GetHealthCenterByState(string State)
        {
           return   _Context.healthCenters.Include(x => x.Country)
            .Where(x => x.address.State.ToUpper() == State.ToUpper())
            .ToList();
        }

        public HealthCenter GetHealthCenterInfo(int Id)
        {
          var PH =   _Context.healthCenters
            .Include(x => x.Country)
            .Include(a => a.images)
            .Include(b => b.HealthCenterName)
            .Include(d => d.PhoneNumber )
            .Include(b => b.HoursOfWork)
            .Include(c => c.Category).SingleOrDefault(e => e.Id == Id);
            return PH;
        }

        public HealthCenterDto ReturnById(int Id)
        {
           
             var healtH = _Context.healthCenters.SingleOrDefault(x => x.Id == Id);
            return new HealthCenterDto
            {
                HealthCenterName = healtH.HealthCenterName,
                IHealthCenterImage = healtH.Image,
                    Category = healtH.Category,
                    Email = healtH.Email,
                    PhoneNumber = healtH.PhoneNumber,
                    WebsiteUrl = healtH.WebsiteUrl,
                    Description = healtH.Description,
                 
                    healthCenterServices = healtH.healthCenterServices,
                    HoursOfWork = healtH.HoursOfWork,
                    Images = (ICollection<ImageDTO>)healtH.images,
                    UserId = (int)healtH.UserId,
                       Country = healtH.Country,
                  LocalGovernmentArea = healtH.LocalGovernmentArea,
                  PostalCode = healtH.PostalCode,
                  City = healtH.City,
                  StreetAddress = healtH.StreetAddress,
                  State = healtH.State,
           };
        }

        public IList<HealthCenterDto> Search(string Text)
        {
            return _Context.healthCenters.Where(L => EF.Functions.Like(L.
            Country, $"% {Text} %") )
            .Select(healthCente => new HealthCenterDto 
            {
                      Id = healthCente.Id,
                  Country = healthCente.Country,
                  LocalGovernmentArea = healthCente.LocalGovernmentArea,
                  PostalCode = healthCente.PostalCode,
                  City = healthCente.City,
                  StreetAddress = healthCente.StreetAddress,
                  State = healthCente.State,

                HealthCenterName = healthCente.HealthCenterName,
                Category = healthCente.Category,
                HoursOfWork = healthCente.HoursOfWork,
                healthCenterServices = healthCente.healthCenterServices,
                Email = healthCente.Email,
                WebsiteUrl = healthCente.WebsiteUrl,
                Description = healthCente.Description,
              IHealthCenterImage = healthCente.Image,
                PhoneNumber = healthCente.PhoneNumber ,
            }).ToList();
        }

        public HealthCenter Update(HealthCenter healthCenter)
        {
            _Context.healthCenters.Update(healthCenter);
            _Context.SaveChanges();
            return healthCenter;
        }
    }
     
}