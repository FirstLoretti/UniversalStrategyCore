using System.Numerics;
using UniversalStrategyCore.Armies.States;
using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Units;

namespace UniversalStrategyCore.Armies;

public class Army(int id, FactionName factionName, UnitType unitType, int unitsCount, ArmyStrategicStats strategicStats) : IArmy
{
    public int Id { get; } = id;
    public FactionName FactionName { get; } = factionName;
    public UnitType UnitType { get; } = unitType;
    public int UnitsCount { get; private set; } = unitsCount;
    public ArmyStrategicStats Stats { get; } = strategicStats;
    //public bool IsDestroyed => UnitsCount <= 0;
    //public IArmyState CurrentState => _currentState;
    public event Action<Army>? ArmyDestroyed;

    private IArmyState _currentState = new ArmyStateIdle();

    public void ChangeState(IArmyState armyState)
    {
        _currentState = armyState;
    }

    public void MoveTo(Vector2 destination)
    {
        _currentState.MoveTo(this, destination);
    }

    public void OnTurnEnd()
    {
        TurnEndPenalties();
    }

    public void TakeCasualties(float percent)
    {
        var clampedPercent = float.Clamp(percent, 0f, 100f);
        int casualties = (int)(UnitsCount * (clampedPercent / 100f));
        var clampedCasualties = int.Clamp(casualties, 0, UnitsCount);
        TakeCasualties(clampedCasualties);
    }

    public void MoralePenalty(float percent)
    {
        var clampedPercent = float.Clamp(percent, 0f, 100f);
        Stats.Morale = Math.Max(0f, Stats.Morale - Stats.Morale * (clampedPercent / 100f));
    }

    public void DestroyAllUnits()
    {
        TakeCasualties(UnitsCount);
    }

    private void TurnEndPenalties()
    {
        _currentState.ApplyTurnEndPenalties(this);
    }

    private void TakeCasualties(int units)
    {
        UnitsCount -= units;
        if (UnitsCount <= 0)
        {
            ArmyDestroyed?.Invoke(this);
        }
    }
}