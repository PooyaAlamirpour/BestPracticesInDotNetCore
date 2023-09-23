namespace BestPracticeInDotNet.Presentation.Server.Commons.Models.CustomerDto;

public record UpdateCustomerDto(
    Guid CustomerId,
    string? PhoneNumber,
    string? BankAccountNumber);