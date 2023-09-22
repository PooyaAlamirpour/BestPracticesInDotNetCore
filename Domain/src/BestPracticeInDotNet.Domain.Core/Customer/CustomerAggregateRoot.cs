using BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;
using BestPracticeInDotNet.Domain.Core.Events;
using BestPracticeInDotNet.framework.DDD;
using MediatR;

namespace BestPracticeInDotNet.Domain.Core.Customer;

public class CustomerAggregateRoot : AggregateRoot<CustomerId>
{
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateOfBirthdate DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public BankAccountNumber BankAccountNumber { get; private set; }

    public CustomerAggregateRoot() { }
    

    private CustomerAggregateRoot(CustomerId customerId, string firstname, string lastname, DateOfBirthdate dateOfBirth, PhoneNumber phoneNumber,
        Email email, BankAccountNumber bankAccountNumber)
    {
        CustomerCreatedDomainEvent @event = new(customerId.Value, firstname, lastname, dateOfBirth.Value, phoneNumber.Value, 
            email.Value, bankAccountNumber.Value);
        RaiseEvent(@event);
        Apply(@event);
    }

    public static CustomerAggregateRoot Create(string firstname, string lastname, string dateOfBirth, string phoneNumber,
        string email, string bankAccountNumber)
    {
        DateOfBirthdate dateOfBirthVObject = DateOfBirthdate.Of(dateOfBirth);
        PhoneNumber phoneNumberVObject = PhoneNumber.Of(phoneNumber);
        Email emailVObject = Email.Of(email);
        BankAccountNumber bankAccountNumberVObject = BankAccountNumber.Of(bankAccountNumber);
        
        CustomerId customerId = CustomerId.Of(Guid.NewGuid());
        CustomerAggregateRoot newCustomer = new(customerId, firstname, lastname, dateOfBirthVObject, phoneNumberVObject, emailVObject,
            bankAccountNumberVObject);
        
        return newCustomer;
    }
    
    public void Update(Guid customerId, string phoneNumber, string bankAccountNumber)
    {
        CustomerUpdatedDomainEvent @event = new(customerId, phoneNumber, bankAccountNumber);
        RaiseEvent(@event);
        Apply(@event);
    }
    
    public void Delete(CustomerId customerId)
    {
        CustomerDeletedDomainEvent @event = new(customerId.Value);
        RaiseEvent(@event);
        Apply(@event);
    }

    public void Apply(CustomerDeletedDomainEvent @event)
    {
        this.Id = CustomerId.Of(@event.CustomerId);
    }

    public void Apply(CustomerUpdatedDomainEvent @event)
    {
        this.Id = CustomerId.Of(@event.CustomerId);
        if (!string.IsNullOrWhiteSpace(@event.PhoneNumber))
        {
            this.PhoneNumber = PhoneNumber.Of(@event.PhoneNumber);
        }
        if (!string.IsNullOrWhiteSpace(@event.BankAccountNumber))
        {        
            this.BankAccountNumber = BankAccountNumber.Of(@event.BankAccountNumber);
        }
    }

    public void Apply(CustomerCreatedDomainEvent @event)
    {
        this.Id = CustomerId.Of(@event.CustomerId);
        this.Firstname = @event.Firstname;
        this.Lastname = @event.Lastname;
        this.DateOfBirth = DateOfBirthdate.Of(@event.DateOfBirth.ToString());
        this.PhoneNumber = PhoneNumber.Of(@event.PhoneNumber);
        this.Email = Email.Of(@event.Email);
        this.BankAccountNumber = BankAccountNumber.Of(@event.BankAccountNumber);
    }

    public override void Apply(INotification @event)
    {
        switch (@event)
        {
            case CustomerCreatedDomainEvent domainEvent: Apply(domainEvent);
                break;
            case CustomerDeletedDomainEvent domainEvent: Apply(domainEvent);
                break;
            case CustomerUpdatedDomainEvent domainEvent: Apply(domainEvent);
                break;
        }
    }
}