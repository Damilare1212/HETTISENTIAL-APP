using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HettisentialMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class ApplicationAdminRepo : IApplicationAdminRepo   // BaseRepo<Administrator>,  IApplicationAdminRepo
    {
        private readonly ApplicationContext _context;
        public ApplicationAdminRepo (ApplicationContext context)
        {
            _context = context;
        }
         public AdministratorDto Create(Administrator admin)
        {
            _context.Administrators.Add(admin);
            _context.SaveChanges();
            return new AdministratorDto
            {
        

                Id = admin.Id,
                FullName = $"{admin.Firstname} {admin.Lastname} ",
                AdminEmail = admin.Email,
                Address = admin.Address,
                AdminImage = admin.AdminImage,
                Gender = admin.Gender,
                DateOfBirth = admin.DateOfBirth,
                FirstName = admin.Firstname,
                LAstName = admin.Lastname,
                PhoneNumber= admin.PhoneNumber,
                AdminCategory = admin.AdministratorType,
              //   AdminImage = admin.AdminImage,

            };
        }

        public void Delete(Administrator admin)
        {
          _context.Administrators.Remove(admin);
            _context.SaveChanges();
        }

        public bool ExistByEmail(string email)
        {
            var Email = _context.Administrators
            .Any(e => e.Email == email);
            return Email;
        }

       

        public Administrator GetAdministratorByType(AdminType AdminType)
        {
           var geT = _context.Administrators
          .SingleOrDefault(s => s.AdministratorType == AdminType );
          return geT;
        }

        public List<AdministratorDto> GetAll()
        {
           return _context.Administrators.Select(admin => new AdministratorDto
            {
                Id = admin.Id,
                FullName = $"{admin.Firstname} {admin.Lastname} ",
              
                AdminEmail = admin.Email,
                
               
                Address = admin.Address,
                AdminImage = admin.AdminImage,
                Gender = admin.Gender,
                DateOfBirth = admin.DateOfBirth,
                FirstName = admin.Firstname,
                LAstName = admin.Lastname,
                PhoneNumber= admin.PhoneNumber,
                AdminCategory = admin.AdministratorType
            }).ToList();
        }

        public Administrator GetByEmail(string email)
        {
           var geT =  _context.Administrators.FirstOrDefault(a => a.Email == email);
           return geT;
        }

        public Administrator GetById(int id)
        {
             return _context.Administrators
             .Where(s=> s.Id==id)
             .SingleOrDefault();
        }

        public AdministratorDto ReturnById(int id)
        {
            var admin = _context.Administrators.FirstOrDefault(a => a.Id == id);
            return new AdministratorDto
            {
                 Id = admin.Id,
                 
                FullName = $"{admin.Firstname} {admin.Lastname} ",
              
                AdminEmail = admin.Email,
                
                Address = admin.Address,
                AdminImage = admin.AdminImage,
                Gender = admin.Gender,
                DateOfBirth = admin.DateOfBirth,
                FirstName = admin.Firstname,
                LAstName = admin.Lastname,
                PhoneNumber= admin.PhoneNumber,
                AdminCategory = admin.AdministratorType
            };
        }

          public bool ExistById(int id)
        {
            var exist = _context.Administrators.Any(e => e.Id == id);
            return exist;
        }

        public Administrator Update(Administrator admin)
        {
             _context.Administrators.Update(admin);
           _context.SaveChanges();
           return admin;
        }

        public Administrator CREATE(Administrator admin)
        {
           _context.Administrators.Add(admin);
           _context.SaveChanges();
           return admin;
        }


































        //  public ApplicationAdminRepo(ApplicationContext context) : base (context)
        //  {
        //      _context = context;
        //  }

        // public async Task<Administrator> GetAdministrator(int id)
        // {
        //     var  GetAdmin = await _context.Administrators
        //     .Include(A => A.User)
        //     .ThenInclude(A => A.UserRoles)
        //     .ThenInclude(A => A.Role)
        //     .Where
        //     (A => A.IsDeleted == false)
        //     .SingleOrDefaultAsync(A => A.Id == id);
        //     return GetAdmin;
        // }

        // public async Task<IEnumerable<Administrator>> GetAllAdministrator()
        // {
        //     var GetAllAdmin = await _context.Administrators
        //     .Include(B => B.User)
        //     .ThenInclude(B => B.UserRoles)
        //     .ThenInclude(B => B.Role)
        //     .Where(B => B.AdministratorType == AdminType.Administrator  && B.IsDeleted == false)
        //     .ToListAsync();
        //     return GetAllAdmin;
        // }

    }
}