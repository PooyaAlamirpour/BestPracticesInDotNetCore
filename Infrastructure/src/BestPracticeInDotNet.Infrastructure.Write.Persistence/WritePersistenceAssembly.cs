using System.Reflection;

namespace BestPracticeInDotNet.Infrastructure.Write.Persistence;

public class WritePersistenceAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();

}