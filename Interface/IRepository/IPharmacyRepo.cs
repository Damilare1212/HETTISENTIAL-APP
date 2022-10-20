
using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IPharmacyRepo{
        
        PharmacyDTo Create (Pharmacy pharmacy);
        Pharmacy get (int Id);
          Pharmacy Update (Pharmacy pharmacy);
         public bool DeleTe (Pharmacy pharmacy);
          List<PharmacyDTo>  GetAllPharmacy();
            PharmacyDTo ReturnById(int Id);  
             public bool ExistById(int id);
            Pharmacy GetPharmacyInfo (int Id);
               bool ExistByEmail (string email);
           IList< Pharmacy  > GetPharmacyByState(string State);
            Pharmacy  GetPharmacyByLGA (string LGA);

    }
}

