using Mc2.CrudTest.Application.Command.Customer.Create;
using Mc2.CrudTest.Application.Command.Customer.Update;
using Mc2.CrudTest.Application.Queries.Customer.Get;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Convertors;

public interface IConvertor
{
    CreateCustomerCommand ToCommand(CreateCustomerDto customer);
    GetCustomerQuery ToQuery(GetCustomerDto dto);
    List<GetCustomerResponse> ToDto(List<CustomerAggregateRoot> customers);
    UpdateCustomerCommand ToCommand(UpdateCustomerDto customer);
}