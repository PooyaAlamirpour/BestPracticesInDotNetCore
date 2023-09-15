namespace Mc2.CrudTest.Presentation.Server.Models;

public record UpdateCustomerDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);