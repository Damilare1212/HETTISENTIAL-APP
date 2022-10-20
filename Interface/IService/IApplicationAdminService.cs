using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Models;

namespace HettisentialMvc
{
    public interface IApplicationAdminService
    {
        //   Task<BaseResponseModel<AdministratorDto>> CreateAdmin (CreateAdminRequestModel model);
        //   Task<BaseResponseModel<AdministratorDto>>  UpdateAdmin(UpdateAdminMeasageRequestModel model, int Id);
        //   Task<BaseResponseModel<AdministratorDto>>  GetAdmin (int Id);
        //   Task<BaseResponseModel<IEnumerable<AdministratorDto>>> GetAllAdmin();
        //    Task<BaseResponseModel<AdministratorDto>> CreateSubAdmin (CreateSubAdminRequestModel model);
        //     Task<bool> DeleteAdmin(int Id);
      
        
      BaseResponseModel<AdministratorDto> Create (CreateAdminRequestModel model);
       
      BaseResponseModel<AdministratorDto> Update (UpdateAdminRequestModel model , int id);
      BaseResponseModel<AdministratorDto> Delete (int id);
      BaseResponseModel<AdministratorDto> GetByEmail (string email);
      BaseResponseModel<AdministratorDto> ReturnById (int id);
      BaseResponseModel<IList<AdministratorDto>> GetAll ();
       BaseResponseModel<AdministratorDto> GetAdminByType (AdminType AdminType);













    }
}