using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Delete;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Server.Controllers.Base;
using BestPracticeInDotNet.Presentation.Server.Convertors;
using BestPracticeInDotNet.Presentation.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Server.Controllers.V1;

[ApiVersion("1.0")]
public class CustomerController : ApiBase
{
    private readonly ISender _sender;
    private readonly IConvertor _convertor;
    public CustomerController(ISender sender, IConvertor convertor)
    {
        _sender = sender;
        _convertor = convertor;
    }
    
    [HttpGet(ApiRoutes.Customer.Get)]
    public async Task<IActionResult> GetCustomers([FromQuery] GetCustomerDto customerDto)
    {
        GetCustomerQuery getCustomerQuery = _convertor.ToQuery(customerDto);
        List<CustomerAggregateRoot> response = await _sender.Send(getCustomerQuery);
        return Ok(_convertor.ToDto(response));
    }

    [HttpPost(ApiRoutes.Customer.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto customer, CancellationToken cancellationToken)
    {
        GetCustomerQuery getCustomerQuery = _convertor.ToQuery(
            new GetCustomerDto(null, null, null, customer.Email, null));
        List<CustomerAggregateRoot> response = await _sender.Send(getCustomerQuery, cancellationToken);
        if (response.Count is not 0) throw new ArgumentException($"{customer.Email} has been created before.");
        
        CreateCustomerCommand createCustomerCommand = _convertor.ToCommand(customer);
        await _sender.Send(createCustomerCommand, cancellationToken);
        return CreatedAtAction(nameof(Create), "Customer is created");
    }

    [HttpPut(ApiRoutes.Customer.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDto customer, CancellationToken cancellationToken)
    {
        UpdateCustomerCommand updateCustomerCommand = _convertor.ToCommand(customer);
        await _sender.Send(updateCustomerCommand, cancellationToken);
        return Ok();
    }

    [HttpDelete(ApiRoutes.Customer.Delete)]
    public async Task<IActionResult> Delete(Guid customerId, CancellationToken cancellationToken)
    {
        DeleteCustomerCommand command = new(customerId);
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }
}