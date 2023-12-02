using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using ToDoList.Models;

namespace ToDoList.Db;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Table>()
            .HasMany(e => e.Tasks)
            .WithOne(e => e.Table)
            .HasForeignKey(e => e.TableId)
            .IsRequired();

        modelBuilder.Entity<Models.Task>()
           .HasOne(e => e.Table)
           .WithMany(e => e.Tasks)
           .IsRequired();
    }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public async System.Threading.Tasks.Task AddEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Add(entity);
        await SaveChangesAsync();
    }

    public Task<List<TEntity>> GetEntities<TEntity>() where TEntity : class
    {
        return Set<TEntity>().ToListAsync();
    }

}