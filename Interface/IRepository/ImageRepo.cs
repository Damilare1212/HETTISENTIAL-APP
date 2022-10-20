

using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IImageRepo{
           ImageDTO Create (Image image);
        
        Image Update (Image image);
        void Delete (Image image);
        Image GetById (int id);
        List<ImageDTO> GetAllImages ();
        IList<ImageDTO> GetImagesPharmacyID (int Id);
         IList<ImageDTO> GetImagesMedicalLAbID (int Id);
          IList<ImageDTO> GetImagesHealthCenerID (int Id);
           IList<ImageDTO> GetImagesHospitalID (int Id);
    }
}