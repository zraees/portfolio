using Microsoft.EntityFrameworkCore;

namespace RestApiAzure.Models;

public class EmployeeDBContext : DbContext
{
    public EmployeeDBContext(DbContextOptions<EmployeeDBContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
           .Property(e => e.Name)
           .IsRequired()
           .HasMaxLength(250);
    }
}
