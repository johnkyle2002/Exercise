using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entity { get; }
        bool Add(IList<TEntity> entities, bool saveChanges = true);
        bool Add(TEntity entity, bool saveChanges = true);
        Task<bool> AddAsync(IList<TEntity> entities, bool saveChanges = true);
        Task<bool> AddAsync(TEntity entity, bool saveChanges = true);
        void Dispose();
        bool Remove(IList<TEntity> entities, bool saveChanges = true);
        bool Remove(TEntity entity, bool saveChanges = true);
        Task<bool> RemoveAsync(IList<TEntity> entities, bool saveChanges = true);
        Task<bool> RemoveAsync(TEntity entity, bool saveChanges = true);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        bool Update(TEntity entity, bool saveChanges = true, byte[] concurrencyStamp = null);
        Task<bool> UpdateAsync(TEntity entity, bool saveChanges = true, byte[] concurrencyStamp = null);
    }
}
