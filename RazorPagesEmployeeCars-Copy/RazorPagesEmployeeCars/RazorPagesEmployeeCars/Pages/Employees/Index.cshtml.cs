using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                                     .Include(e => e.Cars)
                                     .ToListAsync();
        }
    }
}
