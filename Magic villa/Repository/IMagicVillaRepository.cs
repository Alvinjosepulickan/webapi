using Magic_villa.Models;
using System.Linq.Expressions;

namespace Magic_villa.Repository
{
    public interface IMagicVillaRepository:IRepository<Villa>
    {
        Task Update(Villa villa);
    }
}
