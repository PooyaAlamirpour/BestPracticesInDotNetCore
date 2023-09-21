using System.Reflection;

namespace BestPracticeInDotNet.Infrastructure.Persistence;

public class ReadPersistenceAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}