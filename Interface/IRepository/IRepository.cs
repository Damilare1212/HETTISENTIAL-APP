using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HettisentialMvc
{
    public interface IRepository <T>
     {
        //      Task<T> Create (T entity);
        //       Task<T> Update(T entity);
        //     Task<T> Get(int id);
        //     Task<ICollection<T>> Get();
        //     Task<T> Get(Expression<Func<T, bool>> expression);
        //     bool AlreadyExists(Expression<Func<T, bool>> expression);
        //     Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>> expression);
        //      void SaveChanges();
    }
}