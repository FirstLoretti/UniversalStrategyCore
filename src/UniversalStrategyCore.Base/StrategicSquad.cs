using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore;

public class StrategicSquad
{
    public Squad InitialData { get; init; }
    public FactionId HolderFaction { get; init; }

    private readonly IExperienceSquadTable _experienceTable;
    private readonly Unit _unit;
    private int _unitsCount;
    private bool _isAlive => _unitsCount > 0;
    private int _experience;
    private int _level = 1;
    private int _replenishmentValue = 10;
    private int _nonCombatLossesPercent = 20;

    public StrategicSquad(
        Squad squad, IUnitRepository unitRepository, FactionId holderFaction, IExperienceSquadTable experienceTable
    )
    {
        InitialData = squad;
        var result = unitRepository.GetUnit(InitialData.UnitId);
        _unit = result.IsSuccess ? result.Value : throw new Exception(result.Error.Message);
        _unitsCount = InitialData.UnitsCount;
        HolderFaction = holderFaction;
        _experienceTable = experienceTable;
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
        return Error.SquadDestroyed(InitialData.Id);
    }

    public Result<bool> NonCombatLosses()
    {
        if (_isAlive)
        {
            _unitsCount -= int.Max(1, _unitsCount * _nonCombatLossesPercent / 100);
            return true;
        }
        return Error.SquadDestroyed(InitialData.Id);
    }

    public int CalculateCurrentDamage()
    {
        if (!_isAlive) return 0;

        var damage = _unit.Damage * _unitsCount;
        var levelMultiplier = 1.0f + _level + 0.1f;

        return (int)MathF.Ceiling(damage + levelMultiplier);
    }

    public Result<bool> AddExperience(int amount)
    {
        if (!_isAlive) return Error.SquadDestroyed(InitialData.Id);

        _experience += int.Max(0, amount);
        _level = _experienceTable.GetLevel(_experience);

        return true;
    }
}