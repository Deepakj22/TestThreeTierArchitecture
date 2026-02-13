
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
}
