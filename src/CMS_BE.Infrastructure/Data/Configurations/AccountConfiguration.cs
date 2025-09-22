using CMS_BE.Domain.Aggregates.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS_BE.Infrastructure.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("citext");
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).HasColumnType("citext");
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.PasswordHash);

            builder
                .HasMany(x => x.AccountToken)
                .WithOne()
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
