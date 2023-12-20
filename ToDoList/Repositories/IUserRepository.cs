using System.Linq.Expressions;
using ToDoList.Models;

namespace ToDoList.Repositories;

public interface IUserRepository
{
    public System.Threading.Tasks.Task AddUser(string userName, string password);
    public Task<User>? GetUser(string userName, string password);
}
