using System.Reflection;

namespace Mc2.CrudTest.Infrastructure.Persistence;

public class PersistenceAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}