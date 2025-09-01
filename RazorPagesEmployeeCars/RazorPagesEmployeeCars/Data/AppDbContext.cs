using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<Car> Cars { get; set; } = default!;
    }
}
