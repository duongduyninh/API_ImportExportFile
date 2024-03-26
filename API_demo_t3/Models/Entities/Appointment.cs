using System.ComponentModel.DataAnnotations.Schema;

namespace API_demo_t3.Models.Entities
{
    [Table("Appointments")]
    public class Appointment
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string BookedAt { get; set; }
        public string VIN { get; set; }

        public Document Document { get; set; }
    }
}
