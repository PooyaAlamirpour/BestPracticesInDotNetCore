namespace BestPracticeInDotNet.Domain.Core.Exceptions;

public class UserRegistrationFailedException : Exception
{
    public UserRegistrationFailedException() : 
        base("The requested user can not be registered.")
    {
        
    }
}