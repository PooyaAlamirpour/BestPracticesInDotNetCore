namespace BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;

public record GetCustomerDto(
    string? Firstname,
    string? Lastname,
    string? PhoneNumber,
    string? Email,
    string? BankAccountNumber);