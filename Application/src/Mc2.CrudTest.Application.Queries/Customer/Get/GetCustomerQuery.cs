using Mc2.CrudTest.Domain.Core.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Queries.Customer.Get;

public record GetCustomerQuery(
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email,
    string BankAccountNumber) : IRequest<List<CustomerAggregateRoot>>;