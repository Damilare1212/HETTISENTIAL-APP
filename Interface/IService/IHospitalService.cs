using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Models;

namespace HettisentialMvc
{
    public interface IHealthCenterService
    {
        //  Task<BaseResponseModel<HealthCenterDto>> Register (CreateHealthCenterRequestModel model);
        //  Task<BaseResponseModel<HealthCenterDto>> UpdateHealthCenter (UpdateHealthCenterRequestModel model, int Id);
        //  Task<BaseResponseModel<HealthCenterDto>> GetHealthCenter (int id);
        //  Task<BaseResponseModel<HealthCenterDto>> GetHEalthCenterByCategory (HealthCenterCategory Category);
        //  Task<BaseResponseModel<IEnumerable<HealthCenterDto>>> GetAllHealthCCenter();
        //  Task<bool> DeleteHealthCenter(int Id);

         BaseResponseModel<HospitalDto> Register (CreateHospitalRequestModel request);
             BaseResponseModel<HospitalDto> Update (UpdateHospitalRequestModel  request, int id);
                 BaseResponseModel<HospitalDto> GetHospital ( int Id  );
                  BaseResponseModel<HospitalDto> GetHospitalByCategory (HospitalCategory Category);
              BaseResponseModel<List<HospitalDto>>   GetAllHospital();
               BaseResponseModel<bool> Delete (int id);
                BaseResponseModel<HospitalDto> GetByMail(string Email);

                BaseResponseModel<HospitalDto>   GetHospitalByState(string State);  
             BaseResponseModel<HospitalDto>   GetHospitalByLGA(string LGA);    
               BaseResponseModel<HospitalDto> ReturnById (int id); 



         
    }
}