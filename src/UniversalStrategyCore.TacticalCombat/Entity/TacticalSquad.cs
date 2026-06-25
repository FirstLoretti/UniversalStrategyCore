using System.Numerics;
using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Component;

namespace UniversalStrategyCore.TacticalCombat.Entity;

public class TacticalSquad
{
    public int Id { get; }
    public TacticalUnit[] TacticalUnits { get; }
    public SquadMovementComponent MovementComponent { get; }

    private readonly Unit _unit;

    public TacticalSquad(int id, Unit unit, int unitsCount)
    {
        Id = id;
        _unit = unit;
        TacticalUnits = new TacticalUnit[unitsCount];
        MovementComponent = new SquadMovementComponent(this);
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        for (int i = 0; i < TacticalUnits.Length; i++)
        {
            TacticalUnits[i] = new TacticalUnit { Id = i + 1, Position = new Vector2(5f, 5f), Speed = _unit.Speed };
        }
    }
}