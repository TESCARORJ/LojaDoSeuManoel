using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> where);
        Task<bool> VerifyExistsAsync(Expression<Func<TEntity, bool>> where);
    }
}
