using System.Reflection;

namespace Mc2.CrudTest.Domain.Core;

public static class DomainAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}