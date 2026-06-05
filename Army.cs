using System.Numerics;
using InsideTheWar.Factions;
using InsideTheWar.Units;

namespace InsideTheWar.Armies;

public class Army(int id, FactionName factionName, UnitType unitType, int unitsCount, ArmyStats stats)
{
    public int Id { get; private set; } = id;
    public FactionName FactionName { get; private set; } = factionName;
    public UnitType UnitType { get; private set; } = unitType;
    public int UnitsCount { get; private set; } = unitsCount;
    public ArmyStats Stats { get; private set; } = stats;
    public bool IsDestroyed => UnitsCount <= 0;
    public IArmyState CurrentState => _currentState;
    public event Action<Army>? OnArmyDestroyed;

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

    public void TakeCasualties(int units)
    {
        UnitsCount = Math.Max(0, UnitsCount - units);
        if (UnitsCount <= 0)
        {
            OnArmyDestroyed?.Invoke(this);
        }
    }

    public void TakeCasualties(float percent)
    {
        int casualties = (int)(UnitsCount * (percent / 100.0f));
        TakeCasualties(casualties);
    }

    public void MoralePenalty(float percent)
    {
        Stats.Morale = Math.Max(0.0f, Stats.Morale - Stats.Morale * (percent / 100));
    }

    public void DestroyAllUnits()
    {
        TakeCasualties(UnitsCount);
    }

    private void TurnEndPenalties()
    {
        _currentState.TurnEndPenalties(this);
    }
}