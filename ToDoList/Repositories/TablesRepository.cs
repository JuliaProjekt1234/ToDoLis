using System.Linq.Expressions;
using ToDoList.Db;
using ToDoList.Models;
using ToDoList.Models.Dtos;

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

    public Task<List<Table>> GetTables(int userId)
    {
        return _dbContext.GetEntities<Table>(table => table.UserId == userId);
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

    public Task<List<Table>> GetFilteredTables(FilterTableDto filter)
    {
        return _dbContext.GetEntities(GetFilterWhereExpression(filter), GetFilterSelectExpression(filter));
    }

    private Expression<Func<Table, bool>> GetFilterWhereExpression(FilterTableDto filter)
    {
        return table =>
        ToDoListDbContext.Compare(table.Name, filter.tableName)
        || ToDoListDbContext.Compare(table.Description, filter.tableDescription)
        || table.Tasks.Any(task => ToDoListDbContext.Compare(task.Name, filter.taskName) || ToDoListDbContext.Compare(task.Description, filter.taskDescription));
    }

    private Expression<Func<Table, Table>> GetFilterSelectExpression(FilterTableDto filter)
    {
        return table =>
            new Table()
            {
                Id = table.Id,
                Name = table.Name,
                Description = table.Description,
                Color = table.Color,
                Tasks = table.Tasks.Where(task => ToDoListDbContext.Compare(task.Name, filter.taskName) || ToDoListDbContext.Compare(task.Description, filter.taskDescription)).ToList()
            };

    }
}
