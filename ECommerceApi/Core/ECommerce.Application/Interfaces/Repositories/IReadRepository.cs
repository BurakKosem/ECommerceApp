using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IReadRepository<T>
    {
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool tracking = false);

        Task<IList<T>> GetAllByPagingAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool tracking = false, int currentPage = 1, int pageSize = 10);

        Task<T> GetAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool tracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool tracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
