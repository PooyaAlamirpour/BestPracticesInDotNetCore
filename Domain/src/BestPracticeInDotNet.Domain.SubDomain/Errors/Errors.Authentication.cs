using ErrorOr;

namespace BestPracticeInDotNet.Domain.SubDomain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error UserLoginFailedException =>
            Error.Validation(
                code: "Authentication.LoginFailed",
                description: "The requested user can not be logged in.");
    }
}