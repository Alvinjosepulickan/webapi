using Magic_villa.Models;
using System.Linq.Expressions;

namespace Magic_villa.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);

        Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task Create(T villa);
        Task Remove(T villa);
        Task Save();
    }
}
