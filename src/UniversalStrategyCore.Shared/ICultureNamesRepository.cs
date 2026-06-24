namespace UniversalStrategyCore.Shared;

public interface ICultureNamesRepository
{
    public Result<CultureNames> GetCultureNames(FactionId id);
}