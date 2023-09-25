using BestPracticeInDotNet.framework.DDD.Logics;

namespace BestPracticeInDotNet.framework.DDD;

public abstract class ValueObject<TKey> : GenericLogic, IEquatable<ValueObject<TKey>>
{
    public TKey Value { get; set; }
    public abstract IEnumerable<TKey> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var valueObject = (ValueObject<TKey>)obj;

        return GetEqualityComponents()
            .SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject<TKey> left, ValueObject<TKey> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject<TKey> left, ValueObject<TKey> right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject<TKey>? other)
    {
        return Equals((object?)other);
    }
}