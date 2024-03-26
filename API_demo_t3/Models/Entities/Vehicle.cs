using System.ComponentModel.DataAnnotations.Schema;

namespace API_demo_t3.Models.Entities
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string VIN { get; set; }

        public Document Document { get; set; }
    }
}
