using System.Reflection;

namespace Mc2.CrudTest.Application.Command;

public static class CommandApplicationAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}