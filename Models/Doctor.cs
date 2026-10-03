using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Specialization { get; set; } = "";

        public string Image { get; set; } = "";

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}