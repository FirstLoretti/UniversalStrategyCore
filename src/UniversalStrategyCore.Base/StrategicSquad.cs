using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore;

public class StrategicSquad
{
    public Squad InitialData { get; init; }

    private int _unitsCount;
    private readonly Unit _unit;

    public StrategicSquad(Squad squad, IUnitRepository unitRepository)
    {
        InitialData = squad;
        var result = unitRepository.GetUnit(InitialData.UnitId);
        _unit = result.IsSuccess ? result.Value : throw new Exception(result.Error.Message);
        _unitsCount = InitialData.UnitsCount;
    }

    public void OnTurnEnd()
    {
        ReplenishmentUnits(10);
    }

    public Squad GetCurrentData() => InitialData with {UnitsCount = _unitsCount};

    public Result<bool> ReplenishmentUnits(int amount)
    {
        if (_unitsCount > 0)
        {
            _unitsCount = int.Min(_unitsCount + int.Max(0, amount), InitialData.MaxUnits);
            return true;
        }
        return Error.SquadDestroyed(InitialData.Id);
    }
}