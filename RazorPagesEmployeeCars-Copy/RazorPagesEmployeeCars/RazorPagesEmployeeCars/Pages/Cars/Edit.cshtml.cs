using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Car = await _context.Cars.Include(c => c.Employee).FirstOrDefaultAsync(m => m.Id == id);
            if (Car == null) return NotFound();

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", Car.EmployeeId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var count = await _context.Cars.CountAsync(c => c.EmployeeId == Car.EmployeeId && c.Id != Car.Id);
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

            _context.Attach(Car).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cars.Any(e => e.Id == Car.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
