namespace ToDoList.Db;

public interface IToDoListDbContext
{
    Task AddEntity<TEntity>(TEntity entity) where TEntity : class;
    Task<List<TEntity>> GetEntities<TEntity>() where TEntity : class;
}
