using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class ApplicationUserRepo : IApplicationUserRepo //BaseRepo<ApplicationUser>, IApplicationUserRepo
    {

         private readonly ApplicationContext _context;

        public ApplicationUserRepo(ApplicationContext context)
        {
            _context = context;
        }

       

        public PatientDto Create(Patient applicationUser)
        {
             _context.patients.Add(applicationUser);
            _context.SaveChanges();
            return new PatientDto
            {
                
        


                Id = applicationUser.Id,
                Fullname = $"{applicationUser.Firstname} {applicationUser.Lastname}",
                Email = applicationUser.Email,
                Image = applicationUser.UserImage,
                Gender = applicationUser.gender,
                Address= applicationUser.Address,
                DateOfBirth = applicationUser.DateOfBirth,
                
              


            };
        }

        

        public void Delete(Patient patient)
        {
           _context.patients.Remove(patient);
            _context.SaveChanges();
        }

        public bool ExistByEmail(string email)
        {
           var mail = _context.patients.Any(e => e.Email == email);
           return mail;
        }

        public bool ExistById(int Id)
        {
            var ID =  _context.patients.Any(e => e.Id == Id);
            return ID;
        }

       

       

       

       

        public Patient Update(Patient patient)
        {
             _context.patients.Update(patient);
            _context.SaveChanges();
            return patient;
        }

        Patient IApplicationUserRepo.Get(int Id)
        {
            return _context.patients
            .Include(s => s.UserHealthCenters)
            .ThenInclude(l => l.Hospital)
            .FirstOrDefault(a => a.Id == Id);
        }

        List<PatientDto> IApplicationUserRepo.GetAll()
        {
             return _context.patients.Select(applicationUser => new PatientDto
            {
                Id = applicationUser.Id,
                Fullname = $"{applicationUser.Firstname} {applicationUser.Lastname} ",
              
                Email = applicationUser.Email,
                 
                Image = applicationUser.UserImage,
                Gender = applicationUser.gender,
                Address= applicationUser.Address,
                
                DateOfBirth = applicationUser.DateOfBirth,
            }).ToList();
        }

        Patient IApplicationUserRepo.GetByEmail(string email)
        {
              return _context.patients
            .Include(s => s.UserHealthCenters)
            .ThenInclude(l => l.Hospital)
            .FirstOrDefault(a => a.Email == email);
        }

        PatientDto IApplicationUserRepo.ReturnById(int id)
        {
             var applicationUser = _context.patients.FirstOrDefault(a => a.Id == id);
            return new PatientDto
            {
                 Id = applicationUser.Id,
                Fullname = $"{applicationUser.Firstname} {applicationUser.Lastname} ",
              
                Email = applicationUser.Email,
                 
                 
                Image = applicationUser.UserImage,
                Gender = applicationUser.gender,
                Address= applicationUser.Address,
                DateOfBirth = applicationUser.DateOfBirth,
            };
        }











        // public ApplicationUserRepo(ApplicationContext context) : base (context)
        // {
        //     _context = context;
        // }

        // public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        // {
        //      var Getalluser = await _context.ApplicationUsers
        //      .Include(A => A.User)
        //      .ThenInclude(A => A.UserRoles)
        //      .Where(A => A.IsDeleted == false)
        //      .ToListAsync();
        //      return Getalluser;
        // }


        // public async Task<IEnumerable<ApplicationUser>> GetSelectedUsers(List<int> UserIds)
        // {
        //      var SelectedUSer = await _context.ApplicationUsers
        //      .Include(b =>b.User)
        //      .ThenInclude(b => b.UserRoles)
        //     .Where(b=> UserIds.Contains(b.Id) 
        //     && b.IsDeleted  == false)
        //     .ToListAsync();
        //     return SelectedUSer;
        // }

        // public async Task<ApplicationUser> GetUser(int id)
        // {
        //      var Getuser = await _context.ApplicationUsers
        //      .Include(A => A.User)
        //      .ThenInclude(A => A.UserRoles)
        //      .Where(A => A.IsDeleted == false)
        //      .SingleOrDefaultAsync(A => A.Id == id);
        //      return Getuser;
        // }

        // public async Task<IEnumerable<string>> GetUserEmails()
        // {
        //    var UserEmail = await _context.ApplicationUsers
        //    .Select(b => b.Email)
        //    .ToListAsync();
        //    return UserEmail;

    }
}
