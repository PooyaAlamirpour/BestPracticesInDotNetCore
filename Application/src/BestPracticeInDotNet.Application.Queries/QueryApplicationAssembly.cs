using System.Reflection;

namespace BestPracticeInDotNet.Application.Queries;

public class QueryApplicationAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}