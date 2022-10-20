
using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IHealthCenerService{
      
       
        
      //   BaseResponseModel<HealthCenterDto> Register (CreateHealthCenterRequestModel request);
        BaseResponseModel<HealthCenterDto> Create (CreateHealthCenterRequestModel model);
          BaseResponseModel<HealthCenterDto> Update (UpdateHealthCenterRequestModel  request, int id);
           BaseResponseModel<HealthCenterDto> GetHealthCenterById ( int Id  );
          BaseResponseModel<List<HealthCenterDto>>   GetAllHealthCenter();  
          BaseResponseModel<HealthCenterDto>   GetHealthCenterByState(string State);  
             BaseResponseModel<HealthCenterDto>   GetHealthCenterByLGA(string LGA);   
             BaseResponseModel<bool> Delete (int id);
               BaseResponseModel<HealthCenterDto> ReturnById (int id);

               

                BaseResponseModel<IEnumerable<HealthCenterDto>> Search (string Search);

               
              

        


    }
}