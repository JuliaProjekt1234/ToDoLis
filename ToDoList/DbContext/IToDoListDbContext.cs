using System.Linq.Expressions;
using ToDoList.Models;

namespace ToDoList.Db;

public interface IToDoListDbContext
{
    public System.Threading.Tasks.Task AddEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;
    public Task<List<TEntity>> GetEntities<TEntity>() where TEntity : BaseEntity;
    public Task<List<TEntity>> GetEntities<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> selectEpression) where TEntity : BaseEntity;
    public ValueTask<TEntity> GetEntity<TEntity>(int id) where TEntity : BaseEntity;
    public System.Threading.Tasks.Task UpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;
    public System.Threading.Tasks.Task DeleteEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;
}
