using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using HettisentialMvc.Entities.JoinerTables;

namespace HettisentialMvc
{
    public interface IUserRoleRepository// : IRepository<UserRole>
    {
      //  Task<List<UserRole>> GetUserRoleByUserId(int UserId);
       UserRole  GetUserRoleByUserId(int UserId);
    }
}