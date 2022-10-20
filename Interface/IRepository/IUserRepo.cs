using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace HettisentialMvc
{
    public interface IUserRepo : IRepository<User>
    {
        // Task<User> GetUser(int Id);
        // Task<IEnumerable<User>> GetAllUsers();
        // Task<User> GetUser(Expression<Func<User, bool>> expression);

         UserDto Create (User user);
        UserDto Update (User user);
        User Get (int id);
        bool ExistByEmail(string email);
        
        void Delete (User user);
        User GetByEmail (string email);
        
        List<UserDto> GetAll ();
         
    }
}