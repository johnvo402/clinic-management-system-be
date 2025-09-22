using CMS_BE.Domain.Aggregates.Humans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS_BE.Infrastructure.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);

            builder
                .HasOne(x => x.Patient)
                .WithOne(x => x.Contact)
                .HasForeignKey<Contact>(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
