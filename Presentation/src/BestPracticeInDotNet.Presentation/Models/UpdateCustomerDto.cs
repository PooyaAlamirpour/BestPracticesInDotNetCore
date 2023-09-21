namespace BestPracticeInDotNet.Presentation.Server.Models;

public record UpdateCustomerDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);