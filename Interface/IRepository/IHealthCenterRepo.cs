
using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IHealthCenteRRepo
    {
        
        HealthCenterDto Create (HealthCenter healthCenter);
        HealthCenter get (int Id);
          HealthCenter Update (HealthCenter healthCenter);
         public bool DeleTe (HealthCenter pharmacy);
          List<HealthCenterDto>  GetAllHealthCener();
            HealthCenterDto ReturnById(int Id);  
             public bool ExistById(int id);
            HealthCenter GetHealthCenterInfo (int Id);
               bool ExistByEmail (string email);
           IList< HealthCenter  > GetHealthCenterByState(string State);
            HealthCenter  GetHealthCenterByLGA (string LGA);

            IList< HealthCenterDto>  Search (string Text); 

    }
}
