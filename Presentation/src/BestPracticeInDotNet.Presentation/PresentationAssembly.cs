using System.Reflection;

namespace BestPracticeInDotNet.Presentation.Api;

public class PresentationAssembly
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}