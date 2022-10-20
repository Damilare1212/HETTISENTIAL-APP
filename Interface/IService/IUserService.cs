using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Models;

namespace HettisentialMvc
{
    public interface IUserService
    {
         
        // Task<BaseResponseModel<IEnumerable<UserDto>>> GetAllUser();
        // Task<BaseResponseModel<UserDto>> GetUser(int Id);
        // Task<BaseResponseModel<UserDto>> UserLogin(LoginRequestModel model);
        // Task<BaseResponseModel<UserDto>> AdminLogin(LoginRequestModel model);
        // Task<bool> Delete(int Id);

         BaseResponseModel<UserDto> ReturnById (int id);
        BaseResponseModel<IList<UserDto>> GetAll ();
        BaseResponseModel<UserDto> LogInUser(LoginRequestModel model);
        BaseResponseModel<bool> DeleteUser(int id);
    }
}