using CMS_BE.Domain.Aggregates.Humans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS_BE.Infrastructure.Data.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);

            builder
                .HasOne(x => x.Visit)
                .WithMany()
                .HasForeignKey(x => x.VisitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Drug)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.DrugId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Unit)
                .WithMany()
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
