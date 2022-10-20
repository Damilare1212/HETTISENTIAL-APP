using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Models;

namespace HettisentialMvc
{
    public interface IRoleService
    {
         
        // Task<BaseResponseModel<RoleDto>> CreateRole(CreateRoleRequestModel model);
        // Task<BaseResponseModel<RoleDto>> GetRole(int Id);
        // Task<BaseResponseModel<IEnumerable<RoleDto>>> GetAllRole();
        // Task<BaseResponseModel<RoleDto>> Update(UpdateRoleRequestModel model, int Id);
        // Task<BaseResponseModel<RoleDto>> GetRoleByName(string RoleName);
        // Task<bool> Delete (int Id);

        
        BaseResponseModel<RoleDto> Create (CreateRoleRequestModel model);
        BaseResponseModel<RoleDto> Update (UpdateRoleRequestModel model , int id);
        BaseResponseModel<RoleDto> Delete (int id);
        BaseResponseModel<RoleDto> GetByEmail (string email);
        BaseResponseModel<RoleDto> ReturnById (int id);
        BaseResponseModel<IList<RoleDto>> GetAll ();
    }
    
}