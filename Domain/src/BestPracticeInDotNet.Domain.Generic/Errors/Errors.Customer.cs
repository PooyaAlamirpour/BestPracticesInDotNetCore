using ErrorOr;

namespace BestPracticeInDotNet.Domain.Generic.Errors;

public static partial class Errors
{
    public static class Customer
    {
        public static class Id
        {
            public static Error Empty => Error.Validation(
                "Customer.Id.Empty",
                "Customer Id is required.");
        }
        
        public static class Firstname
        {
            public static Error Empty => Error.Validation(
                "Customer.Firstname.Empty",
                "Customer firstname is required.");
        }
        
        public static class Lastname
        {
            public static Error Empty => Error.Validation(
                "Customer.Lastname.Empty",
                "Customer lastname is required.");
        }
        
        public static class Email
        {
            public static Error Empty => Error.Validation(
                "Customer.Email.Empty",
                "Customer email is required.");
        }
        
        public static class PhoneNumber
        {
            public static Error Empty => Error.Validation(
                "Customer.PhoneNumber.Empty",
                "Customer phone number is required.");
        }
        
        public static class DateOfBirth
        {
            public static Error Empty => Error.Validation(
                "Customer.DateOfBirth.Empty",
                "Customer birthdate is required.");
        }
    }
}