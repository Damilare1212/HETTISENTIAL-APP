

using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;

namespace HettisentialMvc
{
    
    public class ImageRepo : IImageRepo
    {
            private readonly ApplicationContext _context;
        public ImageRepo(ApplicationContext context)
        {
            _context = context;
        }
         
        public ImageDTO Create(Image image)
        {
            _context.Add(image);
            _context.SaveChanges();
            return new ImageDTO

            {
                ImageName = image.ImagePath,
               
            };

        }

        public void Delete(Image image)
        {
            throw new System.NotImplementedException();
        }

        public List<ImageDTO> GetAllImages()
        {
            throw new System.NotImplementedException();
        }

        public Image GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<ImageDTO> GetImagesHealthCenerID(int Id)
        {
            var imgs =  _context.Images.Where(x => x.healthCenterID == Id)
            .Select(d => new ImageDTO
           {
               ImageName = d.ImagePath,
            

           }).ToList();
           return imgs;
        }

        public IList<ImageDTO> GetImagesHospitalID(int Id)
        {
              var imgs =  _context.Images.Where(x => x.hospitalID == Id)
            .Select(d => new ImageDTO
           {
               ImageName = d.ImagePath,
            

           }).ToList();
           return imgs;
        }

        public IList<ImageDTO> GetImagesMedicalLAbID(int Id)
        {
              var imgs =  _context.Images.Where(x => x.medicalLabID == Id)
            .Select(d => new ImageDTO
           {
               ImageName = d.ImagePath,
            

           }).ToList();
           return imgs;
        }

        public IList<ImageDTO> GetImagesPharmacyID(int Id)
        {
             var imgs =  _context.Images.Where(x => x.PharmacyID == Id)
            .Select(d => new ImageDTO
           {
               ImageName = d.ImagePath,
            

           }).ToList();
           return imgs;
        }

        public Image Update(Image image)
        {
          _context.Images.Update(image);
          _context.SaveChanges();
          return image;
        }
    }
}