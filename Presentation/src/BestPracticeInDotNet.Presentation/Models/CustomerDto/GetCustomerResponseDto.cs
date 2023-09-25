namespace BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;

public record GetCustomerResponseDto(
    Guid Id,
    string Firstname,
    string Lastname,
    string DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
