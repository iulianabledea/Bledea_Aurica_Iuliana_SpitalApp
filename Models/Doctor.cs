using System.ComponentModel.DataAnnotations;

namespace Bledea_Aurica_Iuliana_SpitalApp.Models
{
    // modelul pentru doctori
    public class Doctor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        [Display(Name = "Prenume")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [Display(Name = "Nume")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Specializarea este obligatorie")]
        [Display(Name = "Specializare")]
        public string Specialization { get; set; }

        // cheie straina catre departament
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }

        // proprietate de navigare catre programari
        public ICollection<Appointment>? Appointments { get; set; }
    }


}
