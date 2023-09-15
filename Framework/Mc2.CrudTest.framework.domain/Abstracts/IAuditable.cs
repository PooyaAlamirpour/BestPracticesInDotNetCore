namespace Mc2.CrudTest.framework.DDD.Abstracts;

public interface IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}