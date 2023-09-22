namespace BestPracticeInDotNet.Infrastructure.Authentication.DatetimeProvider;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}