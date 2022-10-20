using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Entities.Identities;

namespace HettisentialMvc
{ 
    public interface IRoleRepo 
    {
        // Task<Role> GetRoleByName(string RoleName);
        // Task<IEnumerable<Role>> GetSelectedRoles(List<int> RoleIds);
        Role Create (Role role);
        Role Update (Role role);
        Role Get (int Id);
        void Delete (Role role);
        RoleDto ReturnById (int Id);
        List<RoleDto> GetAll ();
        Role GetByName (string name);
        bool ExistById (int Id);
        bool ExistByName (string name); 
    }
}