using ToDoList.Models;
using ToDoList.Models.Dtos;

namespace ToDoList.Repositories;

public interface ITablesRepository
{
    public System.Threading.Tasks.Task Add(Table table);
    public Task<List<Table>> GetTables(int userId);
    public ValueTask<Table> GetTable(int id);
    public System.Threading.Tasks.Task DeleteTable(Table table);
    public System.Threading.Tasks.Task UpdateTable(Table table);
    public Task<List<Table>> GetFilteredTables(FilterTableDto filter);
}
