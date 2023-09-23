namespace BestPracticeInDotNet.Presentation.Server.Models.CustomerDto;

public record UpdateCustomerDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);