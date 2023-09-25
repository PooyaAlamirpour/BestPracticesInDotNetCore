namespace BestPracticeInDotNet.framework.DDD.Abstracts;

public interface IBusinessRule
{
    bool HasValidRule();
    string Message { get; }
}