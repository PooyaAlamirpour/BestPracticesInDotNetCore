using BestPracticeInDotNet.framework.DDD.Logics;

namespace BestPracticeInDotNet.framework.DDD;

public abstract class ValueObject<TKey> : GenericLogic, IEquatable<ValueObject<TKey>>
{
    public TKey Value { get; set; }
    public abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ValueObject<TKey>)obj);
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
        return EqualityComparer<TKey>.Default.GetHashCode(Value);
    }

    public bool Equals(ValueObject<TKey>? other)
    {
        return Equals((object?)other);
    }
}