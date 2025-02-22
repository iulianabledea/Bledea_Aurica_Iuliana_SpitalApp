using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bledea_Aurica_Iuliana_SpitalApp.Data;
using Bledea_Aurica_Iuliana_SpitalApp.Models;

namespace Bledea_Aurica_Iuliana_SpitalApp.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext _context;

        public IndexModel(Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
    }
   
}
