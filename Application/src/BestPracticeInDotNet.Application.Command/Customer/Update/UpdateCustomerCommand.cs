using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Update;

public record UpdateCustomerCommand(
    Guid CustomerId,
    string PhoneNumber,
    string BankAccountNumber) : IRequest;