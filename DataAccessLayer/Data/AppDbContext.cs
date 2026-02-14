
using Microsoft.EntityFrameworkCore;
using ThreeTierArchitecture.Domain.Entities;

namespace DataAccessLayer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
                    .HasOne(u => u.Employee)
                    .WithOne(e => e.ApplicationUser)
                    .HasForeignKey<Employee>(e => e.ApplicationUserId);

        base.OnModelCreating(modelBuilder);
    }
}
