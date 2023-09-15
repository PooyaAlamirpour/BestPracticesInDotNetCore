namespace Mc2.CrudTest.Presentation.Server.Models;

public record GetCustomerResponse(
    Guid Id,
    string Firstname,
    string Lastname,
    string DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
