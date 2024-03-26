using API_demo_t3.Models.Entities;
using API_demo_t3.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API_demo_t3.Data
{
    public class DbContextBMW : DbContext
    {
        public DbContextBMW(DbContextOptions<DbContextBMW>options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DocumentConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new AppointmentConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());

        }

        public DbSet<Models.Entities.Document> Documents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
