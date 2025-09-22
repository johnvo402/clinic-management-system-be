using CMS_BE.Domain.Aggregates.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS_BE.Infrastructure.Data.Configurations
{
    public class DrugConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);

            builder
                .HasMany(x => x.Units)
                .WithOne(x => x.Drug)
                .HasForeignKey(x => x.DrugId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Prescriptions)
                .WithOne(x => x.Drug)
                .HasForeignKey(x => x.DrugId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
