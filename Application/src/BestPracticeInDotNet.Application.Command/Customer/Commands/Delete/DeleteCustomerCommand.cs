using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Commands.Delete;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest;