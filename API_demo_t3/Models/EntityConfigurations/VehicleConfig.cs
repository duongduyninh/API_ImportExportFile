using API_demo_t3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_demo_t3.Models.EntityConfigurations
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Document)
                .WithMany(x => x.Vehicle)
                .HasForeignKey(u => u.DocumentId);
        }
    }
}
