using System.Collections.Generic;
using HettisentialMvc.Entities.Identities;

namespace HettisentialMvc
{
    public class RoleService : IRoleService
    {
          private readonly IRoleRepo _roleRepository;
         public RoleService(IRoleRepo roleRepo)
         {
             _roleRepository = roleRepo;
         }

        public BaseResponseModel<RoleDto> Create(CreateRoleRequestModel model)
        {
             var role = _roleRepository.GetByName(model.RoleName);
            
            if (role != null)
            {
                return new BaseResponseModel<RoleDto>
                {
                    Status = false,
                    Measage = "Role already exists"
                };
            }
            
            var newRole = new Role
            {
                RoleName = model.RoleName,
                Description = model.Description
            };
            
            _roleRepository.Create(newRole);
            
            return new BaseResponseModel<RoleDto>
            {
                Status = true,
                Measage = "User created successfully"
            };
        }

        public BaseResponseModel<RoleDto> Delete(int id)
        {
            var role = _roleRepository.Get(id);
            if(role == null)
            {
                return new BaseResponseModel<RoleDto>
                {
                    Measage = "Role not found",
                    Status = false
                
                };
            }
            _roleRepository.Delete(role);
            return new BaseResponseModel<RoleDto>
            {
                Measage = "Role successfully Deleted",
                Status = true
            };
        }

        public BaseResponseModel<IList<RoleDto>> GetAll()
        {
             var role = _roleRepository.GetAll();
            if(role == null)
            {
                return new BaseResponseModel<IList<RoleDto>>
                {
                    Measage = "No Role Found",
                    Status = false
                };
            }
            return new BaseResponseModel<IList<RoleDto>>
            {
                Measage = "Role successfully retrieved",
                Status = true,
                Data = role
            };
        }

        public BaseResponseModel<RoleDto> GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponseModel<RoleDto> ReturnById(int id)
        {
             if(!(_roleRepository.ExistById(id)))
            {
                return new BaseResponseModel<RoleDto>
                {
                    Measage = "Role doesn't exist",
                    Status = false
                };
            }
            var role = _roleRepository.ReturnById(id);
            return new BaseResponseModel<RoleDto>
            {
                Measage = "Role successfully retrieved",
                Status = true,
                Data = role
            }; 
        }

        public BaseResponseModel<RoleDto> Update(UpdateRoleRequestModel model, int id)
        {
            var role = _roleRepository.Get(id);
            if(role == null)
            {
                return new BaseResponseModel<RoleDto>
                {
                    Measage = "Role doesn't exist",
                    Status = false
                };
            }

            role.RoleName = model.RoleName ?? role.RoleName;
            role.Description = model.Description ?? role.Description;
            _roleRepository.Update(role);
            return new BaseResponseModel<RoleDto>
            {
                Measage = "Role successfully updated",
                Status = true,
                Data = new RoleDto
                {
                    RoleName = role.RoleName,
                    Description = role.Description
                }
            };
        }
    }
}