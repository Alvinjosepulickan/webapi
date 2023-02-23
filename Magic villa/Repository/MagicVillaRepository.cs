using Magic_villa.DbContexts;
using Magic_villa.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Magic_villa.Repository
{
    public class MagicVillaRepository:Repository<Villa>,IMagicVillaRepository
    {
        private readonly MagicVillaDbContext _context;
        public MagicVillaRepository(MagicVillaDbContext context):base(context) 
        {
            _context = context;
        }
        public async Task Update(Villa villa)
        {
            _context.Villas.Update(villa);
            await base.Save();
        }
    }
}
