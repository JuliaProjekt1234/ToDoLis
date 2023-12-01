using ToDoList.Models;

namespace ToDoList.Repositories;

public interface ITablesRepository
{
    public Task Add(Table table);
    public Task<List<Table>> GetTables();
}
