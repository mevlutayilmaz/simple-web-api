using StudentPortalAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Repositories
{
    public interface IReadRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? method = null, bool enableTracking = false);
        IQueryable<T> GetAllByPaging(Expression<Func<T, bool>>? method = null, int pageCount = 0, int itemCount = 5, bool enableTracking = false);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool enableTracking = false);
        Task<T> GetByIdAsync(string id, bool enableTracking = false);
        Task<int> CountAsync(Expression<Func<T, bool>>? method = null);
    }
}
