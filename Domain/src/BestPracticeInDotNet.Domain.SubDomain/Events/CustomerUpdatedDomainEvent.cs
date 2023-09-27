﻿using BestPracticeInDotNet.framework.DDD.Abstracts;
using MediatR;

namespace BestPracticeInDotNet.Domain.SubDomain.Events;

public record CustomerUpdatedDomainEvent(Guid CustomerId, string PhoneNumber, string BankAccountNumber) : IDomainEvent;