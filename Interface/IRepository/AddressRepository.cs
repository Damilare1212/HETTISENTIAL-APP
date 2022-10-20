
using System.Collections.Generic;

namespace HettisentialMvc
{
    public interface IAddressRepo
    {
           AddressDTo Create (Address address);
        
        Address Update (Address address);
        void Delete (Address address);
        Address GetById (int id);
        
        List<AddressDTo> GetAllAddress ();
          AddressDTo ReturnById (int id);
         public bool ExistById(int id);
    }
}