using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bledea_Aurica_Iuliana_SpitalApp.Data;
using Bledea_Aurica_Iuliana_SpitalApp.Models;

namespace Bledea_Aurica_Iuliana_SpitalApp.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext _context;

        public DeleteModel(Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FirstOrDefaultAsync(m => m.ID == id);

            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                Patient = patient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                Patient = patient;
                _context.Patients.Remove(Patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
