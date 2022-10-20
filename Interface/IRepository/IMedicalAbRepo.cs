
using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IMedicalLabRepo
    {
        
        MedicalLabDTo Create (MedicalLab  medicalLab);
        MedicalLab get (int Id);
          MedicalLab Update (MedicalLab medicalLab);
         public bool DeleTe (MedicalLab medicalLab);
          List<MedicalLabDTo>  GetAllMedicalLab();
            MedicalLabDTo ReturnById(int Id);  
             public bool ExistById(int id);
            MedicalLab GetPharmacyInfo (int Id);
               bool ExistByEmail (string email);
           IList< MedicalLab  > GetMedicalLabByState(string State);
            MedicalLab  GetMedicalLabByLGA (string LGA);

    }
}
