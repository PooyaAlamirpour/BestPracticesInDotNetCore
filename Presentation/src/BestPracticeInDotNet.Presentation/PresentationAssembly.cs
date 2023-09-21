using System.Reflection;

namespace BestPracticeInDotNet.Presentation.Server;

public class PresentationAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}