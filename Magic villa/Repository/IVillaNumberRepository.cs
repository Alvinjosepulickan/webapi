using Magic_villa.Models;
using System.Linq.Expressions;

namespace Magic_villa.Repository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task Update(VillaNumber villaNumber);
    }
}
