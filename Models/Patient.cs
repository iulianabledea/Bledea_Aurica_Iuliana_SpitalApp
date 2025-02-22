using System.ComponentModel.DataAnnotations;

namespace Bledea_Aurica_Iuliana_SpitalApp.Models
{
    // modelul pentru pacienti
    public class Patient
    {
        // id ul se va genera automat ca primary key
        public int ID { get; set; }

        // adaugam data annotations pentru validare
        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        [Display(Name = "Prenume")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [Display(Name = "Nume")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email ul este obligatoriu")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numarul de telefon este obligatoriu")]
        [Phone(ErrorMessage = "Numarul de telefon nu este valid")]
        [Display(Name = "Numar Telefon")]
        public string PhoneNumber { get; set; }

        // proprietate de navigare catre programari
        public ICollection<Appointment>? Appointments { get; set; }
    }
}