using System.Text;
using CleanArchWithCQRSPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<AuditLog> AuditLogs { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntities = ChangeTracker.Entries()
                                            .Where(x => x.State == EntityState.Added
                                                    || x.State == EntityState.Modified
                                                    || x.State == EntityState.Deleted)
                                            .ToList();

        foreach (var entity in modifiedEntities)
        {
            var auditLog = new AuditLog
            {
                EntityName = entity.Entity.GetType().Name,
                Email = "test",
                Action = entity.State.ToString(),
                Timestamp = DateTime.UtcNow,
                Changes = GetModifiedChanges(entity)
            };

            AuditLogs.Add(auditLog);
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private string GetModifiedChanges(EntityEntry entity)
    {
        var changes = new StringBuilder();

        foreach (var property in entity.OriginalValues.Properties)
        {
            var originalVal = entity.OriginalValues[property];
            var currentVal = entity.CurrentValues[property];

            if(Equals(originalVal, currentVal) == false)
            {
                changes.AppendLine($"{property.Name}: Original '{originalVal}' Changed to '{currentVal}'");
            }
        }

        return changes.ToString();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
    }
}
