namespace Mc2.CrudTest.framework.DDD.Abstracts;

public interface IBusinessRule
{
    bool HasValidRule();
    string Message { get; }
}