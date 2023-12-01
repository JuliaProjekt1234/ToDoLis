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

    public async Task Add(Table table)
    {
        await _dbContext.AddEntity(table);
    }

    public Task<List<Table>> GetTables()
    {
        return _dbContext.GetEntities<Table>();
    }
}
