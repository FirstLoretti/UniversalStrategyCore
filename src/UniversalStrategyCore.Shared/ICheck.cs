namespace UniversalStrategyCore.Shared;

public interface ICheck<T>
{
    public bool IsPassed(T entity);
}