using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bledea_Aurica_Iuliana_SpitalApp.Data;
using Bledea_Aurica_Iuliana_SpitalApp.Models;

namespace Bledea_Aurica_Iuliana_SpitalApp.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext _context;

        public EditModel(Bledea_Aurica_Iuliana_SpitalApp.Data.SpitalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lista pentru pacienti
            var patientList = _context.Patients.Select(x => new
            {
                ID = x.ID,
                FullName = x.LastName + " " + x.FirstName
            });

            // Lista pentru doctori
            var doctorList = _context.Doctors.Select(x => new
            {
                ID = x.ID,
                FullName = x.LastName + " " + x.FirstName
            });

            // Liste pentru dropdown-uri
            ViewData["Services"] = new SelectList(Appointment.AvailableServices);
            ViewData["PatientID"] = new SelectList(patientList, "ID", "FullName");
            ViewData["DoctorID"] = new SelectList(doctorList, "ID", "FullName");

            Appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(Appointment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
    }
}
