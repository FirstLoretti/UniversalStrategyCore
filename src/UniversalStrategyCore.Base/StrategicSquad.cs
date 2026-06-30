using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore;

public class StrategicSquad
{
    public int Number {get; init;}
    public Squad InitialData { get; init; }
    public FactionId HolderFaction { get; init; }

    private readonly Unit _unit;
    private int _unitsCount;
    private bool _isAlive => _unitsCount > 0;
    private int _replenishmentValue = 10;
    private int _nonCombatLossesPercent = 20;

    public StrategicSquad(
        int number, Squad squad, IUnitRepository unitRepository, FactionId holderFaction
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

    public Dictionary<GameResourceType, int> GetUpkeep() => new()
    {
        [GameResourceType.Gold] = _unitsCount * _unit.Upkeep
    };

    public Result<bool> ReplenishmentUnits()
    {
        if (_isAlive)
        {
            _unitsCount = int.Min(_unitsCount + _replenishmentValue, InitialData.MaxUnits);
            return true;
        }
        return Error.SquadDestroyed(Number);
    }

    public Result<bool> NonCombatLosses()
    {
        if (_isAlive)
        {
            _unitsCount -= int.Max(1, _unitsCount * _nonCombatLossesPercent / 100);
            return true;
        }
        return Error.SquadDestroyed(Number);
    }
}