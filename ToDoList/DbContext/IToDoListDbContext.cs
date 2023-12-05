using ToDoList.Models;

namespace ToDoList.Db;

public interface IToDoListDbContext
{
    public System.Threading.Tasks.Task AddEntity<TEntity>(TEntity entity) where TEntity : class;
    public Task<List<TEntity>> GetEntities<TEntity>() where TEntity : class;
    public ValueTask<TEntity> GetEntity<TEntity>(int id) where TEntity : BaseEntity;
    public System.Threading.Tasks.Task UpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;
}
