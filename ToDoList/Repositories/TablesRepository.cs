using ToDoList.Db;
using ToDoList.Models;

namespace ToDoList.Repositories;

public class TablesRepository : ITablesRepository
{
    private readonly IToDoListDbContext _dbContext;

    public TablesRepository(IToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async System.Threading.Tasks.Task Add(Table table)
    {
        await _dbContext.AddEntity(table);
    }

    public Task<List<Table>> GetTables()
    {
        return _dbContext.GetEntities<Table>();
    }

    public ValueTask<Table> GetTable(int id)
    {
        return _dbContext.GetEntity<Table>(id);
    }

    public System.Threading.Tasks.Task DeleteTable(Table table)
    {
        return _dbContext.DeleteEntity<Table>(table);
    }
    public System.Threading.Tasks.Task UpdateTable(Table table)
    {
        return _dbContext.UpdateEntity<Table>(table);
    }
}
