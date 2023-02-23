using Magic_villa.DbContexts;
using Magic_villa.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Magic_villa.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly MagicVillaDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(MagicVillaDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public async Task Create(T villa)
        {
            await dbSet.AddAsync(villa);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            var result= await query.FirstOrDefaultAsync();
            return result;
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            var result = query.ToListAsync();
            return result;
        }

        public async Task Remove(T villa)
        {
            dbSet.Remove(villa);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
