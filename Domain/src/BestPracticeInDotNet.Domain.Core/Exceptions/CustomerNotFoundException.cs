namespace BestPracticeInDotNet.Domain.Core.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException() 
        : base($"The requested customer is not found")
    {
    }
}