using API_demo_t3.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_demo_t3.Models.EntityConfigurations
{
    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}
