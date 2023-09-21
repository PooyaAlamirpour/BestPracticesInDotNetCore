using Mc2.CrudTest.Application.Queries.Repositories;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;

public class CustomerReadReadRepository : GenericReadRepository<CustomerAggregateRoot, CustomerId>, ICustomerReadRepository
{
    public CustomerReadReadRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    
    public async Task<List<CustomerAggregateRoot>> GetListByFilter(string firstname, string lastname, string email, string phoneNumber,
        string bankAccountNumber)
    {
        IQueryable<CustomerAggregateRoot>? query = base.QueryableFilter();
        if (!string.IsNullOrWhiteSpace(firstname))
        {
            query = query?.Where(x => x.Firstname.Contains(firstname));
        }
        if (!string.IsNullOrWhiteSpace(lastname))
        {
            query = query?.Where(x => x.Lastname.Contains(lastname));
        }
        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query?.Where(x => x.Email == Email.Of(email));
        }
        if (!string.IsNullOrWhiteSpace(phoneNumber))
        {
            query = query?.Where(x => x.PhoneNumber == PhoneNumber.Of(phoneNumber));
        }
        if (!string.IsNullOrWhiteSpace(bankAccountNumber))
        {
            query = query?.Where(x => x.BankAccountNumber == BankAccountNumber.Of(bankAccountNumber));
        }

        return await query?.ToListAsync()!;
    }
}