namespace BestPracticeInDotNet.framework.DDD.Abstracts;

public interface IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}