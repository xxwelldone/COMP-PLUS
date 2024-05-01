using System.Linq.Expressions;
using COMP_.Context;
using COMP_.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace COMP_.Repository
{
    public class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        protected readonly PostgreeContext _context;
        public BaseRepository(PostgreeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToArrayAsync();
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public T Create(T obj)
        {
             _context.Set<T>().Add(obj);
            return obj;
        }
        public T Update(T obj)
        {
            _context.Set<T>().Update(obj);
            return obj;
        }

        public T Delete(T obj)
        {
           _context.Set<T>().Remove(obj);
            return obj;
        }

    }
}
