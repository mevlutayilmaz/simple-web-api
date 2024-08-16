using Microsoft.EntityFrameworkCore;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Domain.Common;
using StudentPortalAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _dbContext;
        public ReadRepository(AppDbContext dbContext) => _dbContext = dbContext;
        private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? method = null, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if(method is not null) return query.Where(method);
            return query;
        }
        public IQueryable<T> GetAllByPaging(Expression<Func<T, bool>>? method = null, int pageCount = 0, int itemCount = 5, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if (method is not null) return query.Where(method).Skip(itemCount*pageCount).Take(itemCount);
            return query.Skip(itemCount * pageCount).Take(itemCount);
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(string id, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? method = null)
        {
            Table.AsNoTracking();
            if(method is not null) Table.Where(method);
            return await Table.CountAsync();
        }
    }
}
