﻿using MediatR;
using ErrorOr;

namespace BestPracticeInDotNet.Application.Queries.Authentication.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<LoginQueryResponse>>;
