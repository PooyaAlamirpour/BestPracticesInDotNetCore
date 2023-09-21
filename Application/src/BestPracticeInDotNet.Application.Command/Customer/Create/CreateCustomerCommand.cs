using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Create;

public record CreateCustomerCommand(
    string Firstname,
    string Lastname,
    string DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : IRequest;