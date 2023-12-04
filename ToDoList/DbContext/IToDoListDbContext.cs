using ToDoList.Models;

namespace ToDoList.Db;

public interface IToDoListDbContext
{
    System.Threading.Tasks.Task AddEntity<TEntity>(TEntity entity) where TEntity : class;
    Task<List<TEntity>> GetEntities<TEntity>() where TEntity : class;
    ValueTask<TEntity> GetEntity<TEntity>(int id) where TEntity : BaseEntity;
}
