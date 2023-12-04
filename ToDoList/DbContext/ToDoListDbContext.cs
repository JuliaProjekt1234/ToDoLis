using Microsoft.EntityFrameworkCore;
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
           .HasForeignKey(e => e.TableId)
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

    public ValueTask<TEntity> GetEntity<TEntity>(int id) where TEntity : BaseEntity
    {
        return Set<TEntity>().FindAsync(id);
    }

}