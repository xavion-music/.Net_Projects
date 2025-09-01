using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesEmployeeCars.Data;
using RazorPagesEmployeeCars.Models;

namespace RazorPagesEmployeeCars.Pages
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesEmployeeCars.Data.RazorPagesEmployeeCarsContext _context;

        public CreateModel(RazorPagesEmployeeCars.Data.RazorPagesEmployeeCarsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
