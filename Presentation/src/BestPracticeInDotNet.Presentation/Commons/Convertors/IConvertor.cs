﻿using BestPracticeInDotNet.Application.Command.Authentication.Register;
using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Authentication.Login;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Api.Models.AuthenticationDto;
using BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;

namespace BestPracticeInDotNet.Presentation.Api.Commons.Convertors;

public interface IConvertor
{
    CreateCustomerCommand ToCommand(CreateCustomerRequestDto customer);
    GetCustomerQuery ToQuery(GetCustomerRequestDto requestDto);
    List<GetCustomerResponseDto> ToDto(List<CustomerAggregateRoot> customers);
    UpdateCustomerCommand ToCommand(UpdateCustomerRequestDto customer);
    AuthenticationResponseDto ToDto(RegisterCommandResponse result);
    AuthenticationResponseDto ToDto(LoginQueryResponse registerResultValue);
}