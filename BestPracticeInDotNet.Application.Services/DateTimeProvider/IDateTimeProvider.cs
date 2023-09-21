namespace BestPracticeInDotNet.Application.Services.DatetimeProvider;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}