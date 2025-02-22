using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bledea_Aurica_Iuliana_SpitalApp.Models;

namespace Bledea_Aurica_Iuliana_SpitalApp.Pages.Appointments
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

            // Lista pentru servicii - simplificat
            ViewData["Services"] = new SelectList(Appointment.AvailableServices);
            ViewData["PatientID"] = new SelectList(patientList, "ID", "FullName");
            ViewData["DoctorID"] = new SelectList(doctorList, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}