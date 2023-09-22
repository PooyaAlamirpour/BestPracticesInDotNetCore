using ErrorOr;

namespace BestPracticeInDotNet.Domain.Core.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error UserRegistrationFailed => 
            Error.Conflict(
                code: "User.DuplicateEmail",
                description: "The requested user can not be registered.");
    }
}