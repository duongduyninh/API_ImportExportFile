using System.ComponentModel.DataAnnotations.Schema;
namespace API_demo_t3.Models.Entities
{
    [Table("Documents")]
    public class Document
    {
        public int Id { get; set; }
        public string  DocumentNumber { get; set; }
        public string Date { get; set; }
        public string SalePerson { get; set; }


        public ICollection<Customer> Customer { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
