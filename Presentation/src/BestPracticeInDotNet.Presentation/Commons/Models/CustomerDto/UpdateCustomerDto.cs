namespace BestPracticeInDotNet.Presentation.Server.Commons.Models;

public record UpdateCustomerDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);