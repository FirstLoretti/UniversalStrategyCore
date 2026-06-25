namespace UniversalStrategyCore.Shared;

public class UnitRepository : IUnitRepository
{
    private readonly Dictionary<UnitId, Unit> _idToUnit = [];

    public UnitRepository()
    {
        CreateUnits();
    }

    public Result<Unit> GetUnit(UnitId id)
    {
        if (_idToUnit.TryGetValue(id, out var unit)) return unit;

        return Error.NotFound(id, nameof(_idToUnit));
    }

    private void CreateUnits()
    {
        _idToUnit.Add("swordman", new Unit("swordman", "Мечник", UnitType.Swordman, 1f));
        _idToUnit.Add("spearman", new Unit("spearman", "Копейщик", UnitType.Spearman, 1f));
    }
}