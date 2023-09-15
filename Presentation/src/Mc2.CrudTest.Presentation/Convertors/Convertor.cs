using Mc2.CrudTest.Application.Command.Customer.Create;
using Mc2.CrudTest.Application.Command.Customer.Update;
using Mc2.CrudTest.Application.Queries.Customer.Get;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Mc2.CrudTest.Presentation.Server.Convertors;

public class Convertor : IConvertor
{
    public CreateCustomerCommand ToCommand(CreateCustomerDto customer)
    {
        return new CreateCustomerCommand(customer.Firstname, customer.Lastname, customer.DateOfBirth,
            customer.PhoneNumber, customer.Email, customer.BankAccountNumber);
    }

    public GetCustomerQuery ToQuery(GetCustomerDto dto) => 
        new(dto.Firstname, dto.Lastname, dto.PhoneNumber, dto.Email, dto.BankAccountNumber);

    public List<GetCustomerResponse> ToDto(List<CustomerAggregateRoot> customers)
    {
        return customers.Select(x => new GetCustomerResponse(
                x.Id.Value,
                x.Firstname,
                x.Lastname,
                x.DateOfBirth.ToString(),
                x.PhoneNumber.Value,
                x.Email.Value,
                x.BankAccountNumber.Value))
            .ToList();
    }

    public UpdateCustomerCommand ToCommand(UpdateCustomerDto customer) => 
        new(customer.CustomerId, customer.PhoneNumber, customer.BankAccountNumber);
}