using API_demo_t3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_demo_t3.Models.EntityConfigurations
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Document)
                .WithMany(x=>x.Appointment)
                .HasForeignKey(u => u.DocumentId);
        }
    }
}
