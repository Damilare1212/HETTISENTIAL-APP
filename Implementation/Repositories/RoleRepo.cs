using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HettisentialMvc.Entities.Identities;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class RoleRepo : IRoleRepo //BaseRepo<Role> , IRoleRepo
    {
           private readonly ApplicationContext _context;

        public RoleRepo(ApplicationContext context)
        {
            _context = context;
        }

        public Role Create(Role role)
        {
             _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public void Delete(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public bool ExistById(int Id)
        {
            return _context.Roles.Any(e => e.Id == Id);
        }

        public bool ExistByName(string name)
        {
            return _context.Roles.Any(e => e.RoleName == name);
        }

        public Role Get(int Id)
        {
           return _context.Roles.FirstOrDefault(a => a.Id == Id);
        }

        public List<RoleDto> GetAll()
        {
            return _context.Roles.Select(role => new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                Description = role.Description
            }).ToList();
        }

        public Role GetByName(string name)
        {
           return _context.Roles
           .FirstOrDefault(a => a.RoleName == name);
        }

        public RoleDto ReturnById(int Id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == Id);
            return new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                Description = role.Description
            };
        }

        public Role Update(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }


        //  public RoleRepo(ApplicationContext context) : base (context)
        //  {
        //      _context  = context;
        //  }

        // public async  Task<Role> GetRoleByName(string RoleName)
        // {
        //      var getRole = await _context.Roles
        //      .Include(A => A.UserRoles)
        //      .ThenInclude(A => A.User )
        //      .SingleOrDefaultAsync(A => A.RoleName == RoleName
        //      && A.IsDeleted == false);
        //      return getRole;
        // }

        // public  async Task<IEnumerable<Role>> GetSelectedRoles(List<int> RoleIds)
        // {
        //     var SelectedRole = await _context.Roles
        //     .Include(A => A.UserRoles)
        //     .ThenInclude(A => A.User )
        //     .Where(A => RoleIds.Contains(A.Id ) )
        //     .ToListAsync();
        //     return SelectedRole;
        // }


    }
}