

using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IAddressService
    {
        BaseResponseModel<AddressDTo> Create (CreateAddressRequestModel model);
       
      BaseResponseModel<AddressDTo> Update (UpdateAddressRequestModel model , int id);
      BaseResponseModel<AddressDTo> Delete (int id);
        BaseResponseModel<IList<AddressDTo>> GetAll ();
          BaseResponseModel<AddressDTo> ReturnById (int id);
    }
}