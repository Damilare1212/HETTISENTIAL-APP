using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HettisentialMvc.Entities.Identities;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class UserRepo :  IUserRepo //BaseRepo<User>, IUserRepo
    {

          private readonly ApplicationContext _context;

        public UserRepo(ApplicationContext context)
        {
            _context = context;
        }

        public UserDto Create(User user)
        {
           _context.Users.Add(user);
            _context.SaveChanges();
            return new UserDto
            {
                //           public string UserName {get; set; }
                // public string Email {get; set; }
                // public ICollection<RoleDto> Roles {get; set; }
                // public string UserFirstName {get; set; }
                //   public string UserLastName {get; set; }
                //   public string  UserFulName  {get; set; }
                //    public string Password {get; set; }
                // public string ApplicationFullName {get; set; }
               Id = user.Id,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
                
            };
        }

        public void Delete(User user)
        {
             _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool ExistByEmail(string email)
        {
            return _context.Users.Any(y => y.Email == email);
        }

        public bool ExistById(int id)
        {
             return _context.Users.Any(t => t.Id == id);
        }

        public User Get(int id)
        {
           return _context.Users.FirstOrDefault(a => a.Id == id);
        }

        public List<UserDto> GetAll()
        {
            return _context.Users.Select(user => new UserDto
            {
                Id = user.Id,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                Email = user.Email,
                  Password = user.Password,
                UserName = user.UserName,
            }).ToList();
        }

        public User GetByEmail(string email)
        {
           return _context.Users
           .Include(u => u.UserRoles)
           .ThenInclude(r => r.Role)
           .FirstOrDefault(a => a.Email == email);
        }

        public UserDto ReturnById(int id)
        {
           var user = _context.Users.Include(u => u.UserRoles).ThenInclude(r => r.Role).FirstOrDefault(a => a.Id == id);
            return new UserDto
            {
                Id = user.Id,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                Email = user.Email,
                  Password = user.Password,
                UserName = user.UserName,
                Roles = user.UserRoles.Select(r => new RoleDto
                {
                    Id = (int)r.RoleId,
                    RoleName = r.Role.RoleName,
                    Description = r.Role.Description
                }).ToList()
            };
        }

        public UserDto Update(User user)
        {
             _context.Users.Update(user);
            _context.SaveChanges();
            return new UserDto
            {
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                Email = user.Email,
                  Password = user.Password,
                UserName = user.UserName,
            };
        }




        //  public UserRepo(ApplicationContext context) : base (context)
        //  {
        //      _context = context;
        //  }

        // public async Task<IEnumerable<User>> GetAllUsers()
        // {
        //     var GetAllUsers = await _context.Users
        //     .Include(A => A.Administrator)
        //     .Include(A => A.ApplicationUser )
        //     .ThenInclude(A=> A.User)
        //     .ThenInclude(A => A.UserRoles) 
        //     .ThenInclude(A => A.Role )
        //     .Where(A=> A.IsDeleted ==false )
        //     .ToListAsync();
        //     return GetAllUsers;
        // }

        // public async Task<User> GetUser(int Id)
        // {
        //     var GetUser = await _context.Users
        //     .Include(A => A.Administrator)
        //     .Include(A => A.ApplicationUser)
        //     .Include(A => A.UserRoles)
        //     .ThenInclude( A => A.Role)
        //     .SingleOrDefaultAsync(A => A.Id == Id && A.IsDeleted == false);
        //     return GetUser;
        // }

        // public async Task<User> GetUser(Expression<Func<User, bool>> expression)
        // {
        //    var GetUser = await _context.Users 
        //    .Include(A => A.Administrator)
        //    .Include(A => A.ApplicationUser )
        //    .Include(A => A.UserRoles)
        //     .ThenInclude( A => A.Role)
        //      .SingleOrDefaultAsync(expression);
        //      return GetUser;
        // }

    }
}