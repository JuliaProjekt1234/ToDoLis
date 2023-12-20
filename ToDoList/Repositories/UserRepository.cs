using System.Linq.Expressions;
using ToDoList.Db;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IToDoListDbContext _dbContext;
    private readonly IPasswordHasherService _passwordHasherService;

    public UserRepository(
        IToDoListDbContext dbContext,
        IPasswordHasherService passwordHasherService)
    {
        _dbContext = dbContext;
        _passwordHasherService = passwordHasherService;
    }

    public System.Threading.Tasks.Task AddUser(string userName, string password)
    {
        return _dbContext.AddEntity(new User(userName, _passwordHasherService.HashPassword(password)));
    }

    public async Task<User>? GetUser(string userName, string password)
    {
        var user = await _dbContext.GetEntity(FindUserExpression(userName, password));
        if (!_passwordHasherService.VerifyPassword(password, user.HashedPassword)) return null;

        return user;
    }

    public Expression<Func<User, bool>> FindUserExpression(string userName, string password)
    {
        return user => user.Name == userName;
    }
}
