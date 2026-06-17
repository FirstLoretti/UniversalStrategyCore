namespace UniversalStrategyCore;

public interface ICheck<T>
{
    public bool IsPassed(T entity);
}