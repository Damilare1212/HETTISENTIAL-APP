



using System.Collections.Generic;
 
namespace HettisentialMvc
{
    public interface IMedicalLabServices
    {
      
       
        
       //  BaseResponseModel<PharmacyDTo> Register (CreatePharmacyRequestsmodel request);
         BaseResponseModel<MedicalLabDTo> Create (CreateMedicalLabRequestModel model);
          BaseResponseModel<MedicalLabDTo> Update (UpdateMedicalLabRequestModel  request, int id);
           BaseResponseModel<MedicalLabDTo> GetMedicalLabById ( int Id  );
          BaseResponseModel<List<MedicalLabDTo>>   GetAllMedicalLab();  
          BaseResponseModel<MedicalLabDTo>   GetMedicalByState(string State);  
             BaseResponseModel<MedicalLabDTo>   GetMedicalByLGA(string LGA);   
             BaseResponseModel<bool> Delete (int id);
               BaseResponseModel<MedicalLabDTo> ReturnById (int id);
             

        


    }
}