using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var count = await _context.Cars.CountAsync(c => c.EmployeeId == Car.EmployeeId);
            if (count >= 2)
            {
                ModelState.AddModelError("", "An employee can only have 2 cars.");
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", Car.EmployeeId);
                return Page();
            }

            if (!ModelState.IsValid)
            {
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", Car.EmployeeId);
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
