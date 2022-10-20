
namespace HettisentialMvc
{
    public interface IImageService
    {
        BaseResponseModel<ImageDTO> UploadImage (string model);

          BaseResponseModel<ImageDTO> DeleteImage (int Id);

    }
}