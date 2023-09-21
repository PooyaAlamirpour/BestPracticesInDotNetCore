using System.Reflection;

namespace BestPracticeInDotNet.Domain.Core;

public static class DomainAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}