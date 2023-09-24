using BestPracticeInDotNet.Domain.Core.DomainModels.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPracticeInDotNet.Infrastructure.SharedKernel.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("users");

        entity.HasKey(x => x.Id).HasName("PRIMARY");

        entity.Property(x => x.FirstName)
            .HasMaxLength(50)
            .HasColumnName("first_name");
        
        entity.Property(x => x.LastName)
            .HasMaxLength(50)
            .HasColumnName("last_name");

        entity.Property(x => x.Email)
            .HasMaxLength(50)
            .HasColumnName("email");

        entity.HasIndex(x => x.Email)
            .IsUnique();

        entity.Property(x => x.Password)
            .HasMaxLength(50)
            .HasColumnName("password");
        
        entity.Property(x => x.CreatedAt)
            .HasColumnName("created_at");
        
        entity.Property(x => x.ModifiedAt)
            .HasColumnName("modified_at")
            .IsRequired(false);
    }
}