using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPracticeInDotNet.Infrastructure.SharedKernel.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerAggregateRoot>
{
    public void Configure(EntityTypeBuilder<CustomerAggregateRoot> entity)
    {
        entity.ToTable("customers");
        
        entity.HasKey(x => x.Id).HasName("PRIMARY");
        // entity.Property(x => x.Id)
            // .HasConversion(paymentId => paymentId.Value,
                // value => CustomerId.Of(value))
            // .HasColumnName("id");

        entity.Property(x => x.Firstname)
            .HasMaxLength(50)
            .HasColumnName("first_name");
        
        entity.Property(x => x.Lastname)
            .HasMaxLength(50)
            .HasColumnName("last_name");
        
        entity.Property(x => x.DateOfBirth)
            .HasColumnName("date_Of_birth")
            .HasMaxLength(50)
            .HasConversion(birthdate => birthdate.Value,
                value => DateOfBirthdate.Of(value.ToString()));
       
        entity.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(15)
            .HasConversion(phoneNumber => phoneNumber.Value,
                value => PhoneNumber.Of(value.ToString()));

        entity.Property(x => x.Email)
            .HasConversion(email => email.Value,
                value => Email.Of(value.ToString()))
            .HasColumnName("email");

        entity.Property(x => x.BankAccountNumber)
            .HasConversion(bankAccountNumber => bankAccountNumber.Value,
                value => BankAccountNumber.Of(value.ToString()))
            .HasColumnName("bank_account_number");

        entity.Ignore(x => x.Version);

        entity.HasIndex(x => new { x.Firstname, x.Lastname, x.DateOfBirth })
            .IsUnique();

        entity.HasIndex(x => x.Email)
            .IsUnique();
        
        entity.Property(x => x.CreatedAt)
            .HasColumnName("created_at");
        
        entity.Property(x => x.ModifiedAt)
            .HasColumnName("modified_at")
            .IsRequired(false);
    }
}