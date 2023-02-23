using Magic_villa.DbContexts;
using Magic_villa.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Magic_villa.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly MagicVillaDbContext _context;
        public VillaNumberRepository(MagicVillaDbContext context):base(context) 
        {
            _context = context;
        }
        public async Task Update(VillaNumber villaNumber)
        {
            _context.VillaNumbers.Update(villaNumber);
            await base.Save();
        }
    }
}
