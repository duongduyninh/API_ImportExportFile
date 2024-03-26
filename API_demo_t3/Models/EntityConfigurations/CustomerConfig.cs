using API_demo_t3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_demo_t3.Models.EntityConfigurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey( x=>x.Id );

            builder.HasOne(u => u.Document)
                .WithMany(x => x.Customer)
                .HasForeignKey(u => u.DocumentId);
        }
    }
}
