using System.Collections.Generic;
using System.Linq;

namespace HettisentialMvc
{
    public class UserService : IUserService
    {
         private readonly IUserRepo _userRepository;
         public UserService (IUserRepo userRpo)
         {
             _userRepository = userRpo;
         }

        public BaseResponseModel<bool> DeleteUser(int id)
        {
           var user = _userRepository.Get(id);
            if (user == null)
            {
                return new BaseResponseModel<bool>
                {
                    Measage = "User not found",
                    Status = false
                };
            }
            _userRepository.Delete(user);
            return new BaseResponseModel<bool>
            {
                Measage = "User successfully Deleted",
                Status = true,
            };
        }

        public BaseResponseModel<IList<UserDto>> GetAll()
        {
           var users = _userRepository.GetAll();
            if(users == null)
            {
                return new BaseResponseModel<IList<UserDto>>
                {
                    Measage = "No User Found",
                    Status = false
                };
            }
            return new BaseResponseModel<IList<UserDto>>
            {
                Measage = "User successfully retrieved",
                Status = true,
                Data = users
            };
        }

        public BaseResponseModel<UserDto> LogInUser(LoginRequestModel model)
        {
            
            var user = _userRepository.GetByEmail(model.Email);
            if(user == null || user.Password != model.PassWord)
            {
                return new BaseResponseModel<UserDto>
                {
                    Measage = " Invalid Email or Password",
                    Status = false,
                };
            }
            return new BaseResponseModel<UserDto>
            {
                Measage = "User successfully logged in",
                Status = true,
                Data = new UserDto
                {
                    

                   Id = user.Id,
                    Email = user.Email,
                    UserFirstName = user.UserFirstName,
                    UserLastName = user.UserLastName,
                    Password = user.Password,
                    
                    Roles = user.UserRoles.Select(u => new RoleDto
                    {
                        Id = u.Role.Id,
                        RoleName = u.Role.RoleName
                        
                    }).ToList()
                }
            };
        }

        public BaseResponseModel<UserDto> ReturnById(int id)
        {
            throw new System.NotImplementedException();
        }

        // public BaseResponseModel<UserDto> ReturnById(int id)
        // {
        //     if(!(_userRepository.Get(id)))
        //     {
        //         return new BaseResponseModel<UserDto>
        //         {
        //             Measage = "User doesn't exist",
        //             Status = false
        //         };
        //     }
        //     var user = _userRepository.ReturnById(id);
        //     return new BaseResponseModel<UserDto>
        //     {
        //         Measage = "User successfully retrieved",
        //         Status = true,
        //         Data = user
        //     }; 
        // }
    }
}