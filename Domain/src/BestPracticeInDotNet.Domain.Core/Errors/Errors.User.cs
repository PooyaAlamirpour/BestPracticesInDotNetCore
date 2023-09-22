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

        public static Error NotFound(string email) =>
            Error.NotFound(
                code: "User.NotFound",
                description: $"The requested user with {email} email is not found.");

        public static class Email
        {
            public static Error Empty => Error.Validation(
                "User.Email.Empty",
                "User email is required.");
        }

        public static class FirstName
        {
            public static Error Empty => Error.Validation(
                "User.FirstName.Empty",
                "FirstName is required.");
        }
        
        public static class LastName
        {
            public static Error Empty => Error.Validation(
                "User.LastName.Empty",
                "LastName is required.");
        }
        
        public static class Password
        {
            public static Error Empty => Error.Validation(
                "User.Password.Empty",
                "Password is required.");
        }
    }
}