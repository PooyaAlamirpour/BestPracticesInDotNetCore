namespace BestPracticeInDotNet.Infrastructure.Authentication.DatetimeProvider;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}