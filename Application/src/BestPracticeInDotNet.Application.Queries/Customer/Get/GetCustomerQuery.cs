using BestPracticeInDotNet.Domain.Core.Customer;
using MediatR;

namespace BestPracticeInDotNet.Application.Queries.Customer.Get;

public record GetCustomerQuery(
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : IRequest<List<CustomerAggregateRoot>>;