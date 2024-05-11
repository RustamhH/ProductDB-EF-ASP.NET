using Database.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Abstracts
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task Update(T entity);
        Task DeleteAsync(int id);
        Task SaveChanges();
    }
}
