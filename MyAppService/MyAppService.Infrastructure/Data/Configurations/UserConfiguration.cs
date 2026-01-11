
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppService.Domain.Entities;

namespace MyAppService.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user")
                .HasQueryFilter(x => !x.IsDeleted);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100);

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(200);

            builder.Property(x => x.Country)
                .HasColumnName("Country")
                .HasMaxLength(100);

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate");

            builder.Property(x => x.CreatedById)
                .HasColumnName("CreatedById");

            builder.Property(x => x.LastModifiedDate)
                .HasColumnName("LastModifiedDate");

            builder.Property(x => x.LastModifiedById)
                .HasColumnName("LastModifiedById");
        }
    }
}
