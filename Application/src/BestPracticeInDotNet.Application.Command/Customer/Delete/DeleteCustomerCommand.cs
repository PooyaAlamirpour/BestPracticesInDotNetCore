using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Delete;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest;