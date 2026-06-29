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
        _idToUnit.Add(
            "swordman",
            new Unit(
                Id: "swordman", DisplayName: "Мечник", UnitType.Swordman, Speed: 1f, Upkeep: 5,
                Damage: 5
            )
        );
        _idToUnit.Add(
            "spearman",
            new Unit(
                Id: "spearman", DisplayName: "Копейщик", UnitType.Spearman, Speed: 1f, Upkeep: 5,
                Damage: 5
            )
        );
    }
}