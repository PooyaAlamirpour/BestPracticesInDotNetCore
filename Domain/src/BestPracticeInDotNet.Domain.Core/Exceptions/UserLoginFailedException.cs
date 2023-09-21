namespace BestPracticeInDotNet.Domain.Core.Exceptions;

public class UserLoginFailedException : Exception
{
    public UserLoginFailedException() : 
        base("The requested user can not be logged in.")
    {
        
    }
}