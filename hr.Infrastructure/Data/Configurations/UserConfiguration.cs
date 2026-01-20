using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace hr.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Entity.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.User> builder)
    {
        builder.Property(u => u.Role)
            .HasConversion<string>().IsRequired();
    }
}