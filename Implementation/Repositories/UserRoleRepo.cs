using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HettisentialMvc.Entities.JoinerTables;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class UserRoleRepo : IUserRoleRepository  //BaseRepo<UserRole>, IUserRoleRepository

    {
       private readonly ApplicationContext _context;

        public UserRoleRepo(ApplicationContext context)
        {
            _context = context;
        }
        // public UserRoleRepo(ApplicationContext context) : base (context)
        // {
        //     _context = context;
        // }

        // public async Task<List<UserRole>> GetUserRoleByUserId(int UserId)
        // {
        //     var  GetUserRole = await  _context.UserRoles
        //     .Include(A => A.User)
        //     .Include(A=> A.Role)
        //     .Where(A => A.UserId == UserId)
        //     .ToListAsync();
        //     return GetUserRole;
        // }

        
        public UserRole GetUserRoleByUserId(int UserId)
        {
            var getRole = _context.UserRoles
            .Where(s => s.UserId == UserId);
            return (UserRole)getRole;
        }
    }
}