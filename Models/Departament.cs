using System.ComponentModel.DataAnnotations;

namespace Bledea_Aurica_Iuliana_SpitalApp.Models
{
    // modelul pentru departamente
    public class Department
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele departamentului este obligatoriu")]
        [Display(Name = "Nume Departament")]
        public string DepartmentName { get; set; }

        [Display(Name = "Etaj")]
        [Range(0, 10, ErrorMessage = "Etajul trebuie sa fie intre 0 si 10")]
        public int FloorNumber { get; set; }

        // proprietate de navigare catre doctori
        public ICollection<Doctor>? Doctors { get; set; }
    }
}
