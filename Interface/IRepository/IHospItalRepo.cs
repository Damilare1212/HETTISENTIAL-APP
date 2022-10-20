using System.Collections.Generic;
using System.Threading.Tasks;
namespace HettisentialMvc
{
    public interface IHospitAlRepo 
    {
        
        HospitalDto Create (Hospital hospital);
         Hospital  Get (int Id);
         Hospital GetHospitalByCategory(HospitalCategory hospitalCategory);
          Hospital Update (Hospital hospital);
           void Delete (Hospital hospital);
           List<HospitalDto>  GetAllHospital();
             bool ExistByEmail(string email);
             Hospital GetByMail(string email);
               HospitalDto ReturnById(int Id);   
                  bool ExistByName(string name);
         bool ExistById(int id);
                    IList< Hospital  > GetHospitalByState(string State);
            Hospital  GetHospitalByLGA (string LGA);

              // Hospital get (int Id);

                


         
    }
}