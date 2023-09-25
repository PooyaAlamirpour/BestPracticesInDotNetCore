namespace BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;

public record UpdateCustomerRequestDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);