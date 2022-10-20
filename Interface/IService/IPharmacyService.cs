

using System.Collections.Generic;
using System.ComponentModel;
namespace HettisentialMvc
{
    public interface IPharmacyService{
      
       
        
       //  BaseResponseModel<PharmacyDTo> Register (CreatePharmacyRequestsmodel request);
          BaseResponseModel<PharmacyDTo> Update (UpdatePharmacyRequestsmodel  request, int id);
           BaseResponseModel<PharmacyDTo> GetPharmacyById ( int Id  );
          BaseResponseModel<List<PharmacyDTo>>   GetAllPharmacy();  
          BaseResponseModel<PharmacyDTo>   GetPharmacyByState(string State);  
             BaseResponseModel<PharmacyDTo>   GetPharmacyByLGA(string LGA);   
             BaseResponseModel<bool> Delete (int id);
               BaseResponseModel<PharmacyDTo> ReturnById (int id);
                BaseResponseModel<PharmacyDTo> Create (CreatePharmacyRequestsmodel model);

        


    }
}