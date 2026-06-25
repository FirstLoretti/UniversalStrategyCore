namespace UniversalStrategyCore.Shared;

public interface IUnitRepository
{
    public Result<Unit> GetUnit(UnitId id);
}