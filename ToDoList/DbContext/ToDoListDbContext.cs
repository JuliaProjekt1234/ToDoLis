using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoList.Models;

namespace ToDoList.Db;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {

    }

    public DbSet<Table> Tables { get; set; }

    public async Task AddEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Add(entity);
        await SaveChangesAsync();
    }

    public Task<List<TEntity>> GetEntities<TEntity>() where TEntity : class
    {
        return Set<TEntity>().ToListAsync();
    }

}