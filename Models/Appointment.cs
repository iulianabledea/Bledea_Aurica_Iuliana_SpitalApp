using System.ComponentModel.DataAnnotations;

namespace Bledea_Aurica_Iuliana_SpitalApp.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Data programarii este obligatorie")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data Programarii")]
        [FutureDate(ErrorMessage = "Data programarii trebuie sa fie in viitor")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Serviciul este obligatoriu")]
        [Display(Name = "Serviciu Medical")]
        public string ServiceType { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        [Display(Name = "Descriere")]
        [StringLength(500)]
        public string Description { get; set; }

        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

        public int DoctorID { get; set; }
        public Doctor? Doctor { get; set; }

        // Lista serviciilor disponibile
        public static List<string> AvailableServices = new List<string>
        {
            "Consultatie",
            "Ecografie",
            "Biopsie",
            "Analize de sange",
            "Radiografie",
            "EKG",
            "RMN",
            "Computer Tomograf",
            "Vaccinare",
            "Control periodic"
        };
    }
}