using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T>
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        void Update(T entity);  
        void Delete(T entity);

    }
}
