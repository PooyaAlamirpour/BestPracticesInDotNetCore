using System.Reflection;

namespace BestPracticeInDotNet.Application.Command;

public static class CommandApplicationAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}