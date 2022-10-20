using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
    public class BaseRepo<T> : IRepository<T> where T : AuditableEntity, new ()
    {
        protected ApplicationContext _context;
        public BaseRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool AlreadyExists(Expression<Func<T, bool>> expression)
        {
            var Exist = _context.Set<T>().Any(expression);
            return Exist;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
           var Get = await _context.Set<T>
           ().SingleOrDefaultAsync
           (item => item.Id == id && item.IsDeleted == false);
           return Get;
        }

        public async Task<ICollection<T>> Get()
        {
             var Gets = await _context.Set<T>()
             .Where(item => item.IsDeleted == false)
             .ToListAsync<T>();
             return Gets;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var Get = await _context.Set<T>()
            .Where(expression)
             .FirstOrDefaultAsync();
             return Get;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            var GetAll = await _context.Set<T>()
            .Where(expression)
            .ToListAsync();
            return GetAll;
        }

        public void SaveChanges()
        {
            
              _context.SaveChanges();
        }

        public async Task<T> Update(T entity)
        {
             _context.Set<T>()
            .Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}