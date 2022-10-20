

namespace HettisentialMvc
{
  
    public class IMageService : IImageService
    {
            private readonly IImageRepo  _ImageRepo;
            public IMageService (IImageRepo ImageRepo)
            {
                _ImageRepo = ImageRepo;
            }
        public BaseResponseModel<ImageDTO> DeleteImage(int Id)
        {
            var imag = _ImageRepo.GetById(Id);
            if(imag == null)
            {
                return new BaseResponseModel<ImageDTO>
                {
                    Measage = "image not found",
                    Status = false
                
                };
            }
            _ImageRepo.Delete(imag);
            return new BaseResponseModel<ImageDTO>
            {
                Measage = "image successfully Deleted",
                Status = true
            };
        }

        public BaseResponseModel<ImageDTO> UploadImage(string model)
        {
            if (model == null )
            {
                return new BaseResponseModel<ImageDTO>
                {
                    Status = false,
                    Measage = "Value Cannot be null",
                };
            }

            var img = new Image
            {
                ImagePath = model,
            };
            _ImageRepo.Create(img);
            return new BaseResponseModel<ImageDTO>
            {
                Status = true,
                Measage = "  Image Updated successfully ",
            };
        }
    }
}