namespace BestPracticeInDotNet.Presentation.Server.Commons.Models;

public record CreateCustomerDto(
    string Firstname,
    string Lastname,
    string DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
