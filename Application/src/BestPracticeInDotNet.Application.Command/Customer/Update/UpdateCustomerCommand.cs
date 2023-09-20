using MediatR;

namespace Mc2.CrudTest.Application.Command.Customer.Update;

public record UpdateCustomerCommand(
    Guid CustomerId,
    string PhoneNumber,
    string BankAccountNumber) : IRequest;