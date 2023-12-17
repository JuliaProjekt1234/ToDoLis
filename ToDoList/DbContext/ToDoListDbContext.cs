using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using ToDoList.Models;

namespace ToDoList.Db;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {
    }

    [DbFunction("Compare")]
    public static bool Compare(string value, string valueToCompare) =>
        throw new NotImplementedException("Mapping by ef - implemented as tsql function");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDbFunction(typeof(ToDoListDbContext).GetMethod(nameof(Compare),
        new[] { typeof(string), typeof(string) }))
        .HasName("Compare");

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
    public async System.Threading.Tasks.Task AddEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        Set<TEntity>().Add(entity);
        await SaveChangesAsync();
    }


    public Task<List<TEntity>> GetEntities<TEntity>() where TEntity : BaseEntity
    {
        return Set<TEntity>().ToListAsync();
    }

    public ValueTask<TEntity> GetEntity<TEntity>(int id) where TEntity : BaseEntity
    {
        return Set<TEntity>().FindAsync(id);
    }
    public async System.Threading.Tasks.Task UpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        Set<TEntity>().Update(entity);
        await SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task DeleteEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        Set<TEntity>().Remove(entity);
        await SaveChangesAsync();
    }

    public Task<List<TEntity>> GetEntities<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> selectEpression) where TEntity : BaseEntity
    {
        return Set<TEntity>().Where(whereExpression).Select(selectEpression).ToListAsync();
    }
}