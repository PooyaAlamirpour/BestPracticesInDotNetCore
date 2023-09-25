using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Menu.ValueObjects;

public class AverageRating : ValueObject<double>
{
    public int NumRating { get; private set; }

    private AverageRating(double value, int numRating)
    {
        Value = value;
        NumRating = numRating;
    }

    public static AverageRating CreateNew(double rating = 0, int numRating = 0)
    {
        return new AverageRating(rating, numRating);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRating) + rating.Value) / ++NumRating;
    }
    
    public override IEnumerable<double> GetEqualityComponents()
    {
        yield return Value;
    }
}