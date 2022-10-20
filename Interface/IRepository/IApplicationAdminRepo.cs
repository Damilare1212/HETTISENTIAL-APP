using System.Collections.Generic;
using System.Threading.Tasks;
using HettisentialMvc.Entities;

namespace HettisentialMvc
{
    public interface IApplicationAdminRepo //: IRepository<Administrator>
    {
        //  Task<Administrator> GetAdministrator(int id);
        //  Task<IEnumerable<Administrator>> GetAllAdministrator();

          AdministratorDto Create (Administrator admin);
        bool ExistByEmail(string email);

         Administrator CREATE (Administrator admin);
       
        Administrator Update (Administrator admin);
        void Delete (Administrator admin);
        Administrator GetById (int id);
        Administrator GetByEmail (string email);
        AdministratorDto ReturnById (int id);
         public bool ExistById(int id);
        List<AdministratorDto> GetAll ();
        Administrator GetAdministratorByType (AdminType AdminType);
    }
}