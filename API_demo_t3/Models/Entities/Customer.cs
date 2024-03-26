using System.ComponentModel.DataAnnotations.Schema;

namespace API_demo_t3.Models.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string CustomerName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Document Document { get; set; }
    }
}
