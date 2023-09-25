using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject<Guid>
{
    private MenuReviewId(Guid value)
    {
        this.Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        yield return Value;
    }
}