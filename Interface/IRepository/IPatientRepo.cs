using System.Collections.Generic;
using System.Threading.Tasks;
namespace HettisentialMvc
{
    public interface IApplicationUserRepo //: IRepository<ApplicationUser>

    {
        // Task<ApplicationUser> GetUser (int id);
        // Task<IEnumerable<ApplicationUser>> GetAllUser();
        // Task<IEnumerable<ApplicationUser>> GetSelectedUsers(List<int> UserIds);
        // Task<IEnumerable<string>> GetUserEmails();

        PatientDto Create (Patient applicationUser);
         Patient Update (Patient patient);
         Patient Get (int Id);
         bool ExistByEmail (string email);
         public bool ExistById(int Id);
         void Delete (Patient patient);
         Patient GetByEmail (string email);
        PatientDto ReturnById (int id);
        List< PatientDto > GetAll ();

    }  
}       