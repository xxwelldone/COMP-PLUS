using System.Linq.Expressions;

namespace COMP_.Repository.Interface
{
    public interface IBaseRespository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        T Create(T obj);
        T Update(T obj);
        T Delete (T obj);
        

    }
}
