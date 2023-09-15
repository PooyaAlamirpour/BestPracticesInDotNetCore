namespace Mc2.CrudTest.Presentation.Server.Controllers.Base;

public static partial class ApiRoutes
{
    public static class Customer
    {
        public const string Get = "customer";
        public const string Create = "customer";
        public const string Update = "customer/{customerId:guid}";
        public const string Delete = "customer/{customerId:guid}";
    }
}