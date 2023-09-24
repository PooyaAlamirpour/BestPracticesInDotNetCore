namespace BestPracticeInDotNet.Presentation.Api.Controllers.Base;

public static partial class ApiRoutes
{
    public static class Authentication
    {
        public const string Register = "register";
        public const string Login = "login";
    }
    
    public static class Customer
    {
        public const string Get = "customers";
        public const string Create = "customer";
        public const string Update = "customer/{customerId:guid}";
        public const string Delete = "customer/{customerId:guid}";
    }

    public static class Dinner
    {
        public const string Get = "dinners";
    }
}