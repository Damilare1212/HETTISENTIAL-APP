using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Models;

namespace HettisentialMvc
{
    public interface IApplicationUSerService
    {
        //  Task<BaseResponseModel<ApplicationUserDto>> CreateUser(ApplicationUserCreateRequestModel model);
        //  Task<BaseResponseModel<ApplicationUserDto>> UpdateUser(UpdateUserRequestModel model, int Id);
        //  Task<BaseResponseModel<ApplicationUserDto>> GetUser(int Id);
        //  Task<BaseResponseModel<IEnumerable<ApplicationUserDto>>> GetAllUser();
        //  Task<bool> Delete(int Id);

         BaseResponseModel<PatientDto> Create (CreatePatientRequestModel model);
        BaseResponseModel<PatientDto> Update (UpdatePatientRequestModel model , int id);
        BaseResponseModel<PatientDto> Delete (int id);
        BaseResponseModel<PatientDto> GetByEmail (string email);
        BaseResponseModel<PatientDto> ReturnById (int id);
        BaseResponseModel<IList<PatientDto>> GetAll ();
         
    }
}