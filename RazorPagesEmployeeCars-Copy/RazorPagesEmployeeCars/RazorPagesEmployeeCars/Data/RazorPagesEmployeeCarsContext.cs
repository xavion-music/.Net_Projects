using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Data
{
    public class RazorPagesEmployeeCarsContext : DbContext
    {
        public RazorPagesEmployeeCarsContext (DbContextOptions<RazorPagesEmployeeCarsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesEmployeeCars.Models.Employee> Employee { get; set; } = default!;
        public DbSet<RazorPagesEmployeeCars.Models.Car> Car { get; set; } = default!;
    }
}
