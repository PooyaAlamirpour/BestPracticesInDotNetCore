namespace BestPracticeInDotNet.Application.Services.DateTimeProvider;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}