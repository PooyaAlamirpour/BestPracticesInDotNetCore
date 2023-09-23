namespace BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;

public record UpdateCustomerDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);