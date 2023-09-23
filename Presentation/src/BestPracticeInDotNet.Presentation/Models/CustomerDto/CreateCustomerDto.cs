namespace BestPracticeInDotNet.Presentation.Server.Models.CustomerDto;

public record CreateCustomerDto(
    string Firstname,
    string Lastname,
    string DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
