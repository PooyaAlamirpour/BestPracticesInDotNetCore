namespace Mc2.CrudTest.Presentation.Server.Models;

public record GetCustomerDto(
    string? Firstname,
    string? Lastname,
    string? PhoneNumber,
    string? Email,
    string? BankAccountNumber);