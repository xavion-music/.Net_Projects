using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                                .Include(c => c.Employee)
                                .ToListAsync();
        }
    }
}
