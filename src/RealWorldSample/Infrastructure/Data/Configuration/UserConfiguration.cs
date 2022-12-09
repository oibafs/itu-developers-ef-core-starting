using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealWorldSample.Domain.Entities;

namespace RealWorldSample.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Bio)
            .IsRequired()
            .HasMaxLength(2000);
    }
}
