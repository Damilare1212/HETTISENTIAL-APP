using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class HealthRepo : IHospitAlRepo  // BaseRepo<Healthcenter>, IHealthCenterRepo

    {

          private readonly ApplicationContext _context;
        public HealthRepo(ApplicationContext context)
        {
            _context = context;
        }
         
           

        public HospitalDto Create(Hospital hospital)
        {
             _context.Hospitals.Add(hospital);
            _context.SaveChanges();
            return new HospitalDto
            {
 

                Id = hospital.Id,
                HealthCenterName = hospital.Name,
               // HealthCenterAddress = hospital.Address,
                HealthCenterImage = hospital.HospitalImage,
                HealthCenterPhoneNumber = hospital.PhoneNumber,
                HEalthCenterEmail= hospital.Email,
                HoursOfWork = hospital.HoursOfWork,
                HealthCenterCategory= hospital.HealthCenterCategory,
                Image = hospital.Image,
                


                 Country = hospital.Country,
                  LocalGovernmentArea = hospital.LocalGovernmentArea,
                  PostalCode = hospital.PostalCode,
                  City = hospital.City,
                  StreetAddress = hospital.StreetAddress,
                  State = hospital.State,


            };
        }
        

        
        public void Delete(Hospital hospital)
        {
            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();
        }

        public bool ExistByEmail(string email)
        {

            return _context.Hospitals.Any(t => t.Email == email);
        }

        public bool ExistById(int id)
        {
             var res = _context.Hospitals.Any(t => t.Id == id);
             return res;
        }

        public bool ExistByName(string name)
        {
             return _context.Hospitals.Any(t => t.Name == name);
        }

        public Hospital get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Hospital Get(int Id)
        {
             var res =  _context.Hospitals.FirstOrDefault(t => t.Id 
             == Id);
           return res;
        }

        public List<HospitalDto> GetAllHospital()
        {
            return _context.Hospitals.Select(hospital => new  HospitalDto
            {
                Id = hospital.Id,
              
                HealthCenterName = hospital.Name,
               
                HealthCenterImage = hospital.HospitalImage,
                HealthCenterPhoneNumber = hospital.PhoneNumber,
                HEalthCenterEmail= hospital.Email,
                HoursOfWork = hospital.HoursOfWork,
               
                HealthCenterCategory= hospital.HealthCenterCategory,

                  Country = hospital.Country,
                  LocalGovernmentArea = hospital.LocalGovernmentArea,
                  PostalCode = hospital.PostalCode,
                  City = hospital.City,
                  StreetAddress = hospital.StreetAddress,
                  State = hospital.State,



            }).ToList();
        }

        public Hospital GetByMail(string email)
        {
             return _context.Hospitals.SingleOrDefault(h => h.Email == email);
        }

        
        public Hospital GetHospitalByCategory(HospitalCategory hospitalCategory)
        {
            var geT = _context.Hospitals
            .Include(f => f.HealthCenterCategory)
            .Where(s => s.HealthCenterCategory == hospitalCategory);
            return (Hospital)geT;
        }

        public Hospital GetHospitalByLGA(string LGA)
        {
            return (Hospital)_context.Hospitals.Include(x => x.State)
            .Where(x => x.address.LocalGovernmentArea.ToUpper() == LGA.ToUpper());
        }

        public IList<Hospital> GetHospitalByState(string State)
        {
            return   _context.Hospitals.Include(x => x.Country)
            .Where(x => x.address.State.ToUpper() == State.ToUpper())
            .ToList();
        }

        public HospitalDto ReturnById(int Id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(r => r.Id == Id);
            return new HospitalDto
            {
                Id = hospital.Id,
              //  HealthCenterAddress = hospital.Address,
                HealthCenterName = hospital.Name,
                  
               
                HealthCenterImage = hospital.HospitalImage,
                HealthCenterPhoneNumber = hospital.PhoneNumber,
                HEalthCenterEmail= hospital.Email,
                HoursOfWork = hospital.HoursOfWork,
                HealthCenterCategory= hospital.HealthCenterCategory,
            };
        }

        

        public Hospital Update(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            _context.SaveChanges();
            return hospital;
        }

        // Hospital IHealthCenterRepo.Get(int Id)
        // {
        //      var res =  _context.Hospitals.FirstOrDefault(t => t.Id 
        //      == Id);
        //    return res;
        // }


        

    }
}