using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore;

public class StrategicSquad
{
    public int Number { get; init; }
    public Squad InitialData { get; init; }
    public FactionId HolderFaction { get; init; }

    private readonly Unit _unit;
    private int _unitsCount;
    private bool IsAlive => _unitsCount > 0;
    private int _replenishmentValue = 10;
    private int _nonCombatLossesPercent = 20;

    public StrategicSquad(
        int number,
        Squad squad,
        IUnitRepository unitRepository,
        FactionId holderFaction
    )
    {
        Number = number;
        InitialData = squad;
        var result = unitRepository.GetUnit(InitialData.UnitId);
        _unit = result.IsSuccess ? result.Value : throw new Exception(result.Error.Message);
        _unitsCount = InitialData.UnitsCount;
        HolderFaction = holderFaction;
    }

    public Squad GetCurrentData() => InitialData with { UnitsCount = _unitsCount };

    public Dictionary<GameResourceType, int> GetUpkeep() => _unit.Upkeep;

    public Result<bool> ReplenishmentUnits()
    {
        if (IsAlive)
        {
            _unitsCount = int.Min(_unitsCount + _replenishmentValue, InitialData.MaxUnits);
            return true;
        }
        return Error.SquadDestroyed(Number);
    }

    public Result<bool> NonCombatLosses()
    {
        if (IsAlive)
        {
            _unitsCount -= int.Max(1, _unitsCount * _nonCombatLossesPercent / 100);
            return true;
        }
        return Error.SquadDestroyed(Number);
    }
}