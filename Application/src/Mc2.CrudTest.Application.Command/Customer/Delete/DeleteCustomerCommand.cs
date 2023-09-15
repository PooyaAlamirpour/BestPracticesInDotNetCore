using MediatR;

namespace Mc2.CrudTest.Application.Command.Customer.Delete;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest;