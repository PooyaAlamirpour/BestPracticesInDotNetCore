using System.Reflection;

namespace Mc2.CrudTest.Infrastructure.Persistence;

public class ReadPersistenceAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}