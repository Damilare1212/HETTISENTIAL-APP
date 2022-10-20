
namespace HettisentialMvc
{
    public class BaseResponseModel<T>
    {
        public string Measage {get; set; }
        public bool Status {get; set; }
        public T Data {get; set; }
    }
}