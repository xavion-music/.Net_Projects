using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                                      .Include(e => e.Cars)
                                      .ToListAsync();
        }
    }
}
