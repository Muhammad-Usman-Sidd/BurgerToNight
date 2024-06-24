using BurgerToNight.Data;
using BurgerToNight.Models.DTOs;
using BurgerToNight.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BurgerToNight.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BurgerDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(BurgerDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {

            await dbSet.AddAsync(entity);
            await SaveAsync();

        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
            var objs = await dbSet.ToListAsync();
            return objs;
        }


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

 
    }
}
