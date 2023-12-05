using ToDoList.Models;

namespace ToDoList.Repositories;

public interface ITablesRepository
{
    public System.Threading.Tasks.Task Add(Table table);
    public Task<List<Table>> GetTables();
    public ValueTask<Table> GetTable(int id);
    public System.Threading.Tasks.Task DeleteTable(Table table);

}
