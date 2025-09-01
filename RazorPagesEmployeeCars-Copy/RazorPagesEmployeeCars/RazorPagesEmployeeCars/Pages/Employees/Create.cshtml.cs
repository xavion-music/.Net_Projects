using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
