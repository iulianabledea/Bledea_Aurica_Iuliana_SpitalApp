using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bledea_Aurica_Iuliana_SpitalApp.Data;
using Bledea_Aurica_Iuliana_SpitalApp.Models;

namespace Bledea_Aurica_Iuliana_SpitalApp.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext _context;

        public CreateModel(Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "DepartmentName");
            return Page();
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Doctors.Add(Doctor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
