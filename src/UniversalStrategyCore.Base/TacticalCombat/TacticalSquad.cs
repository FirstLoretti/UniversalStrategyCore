using System.Numerics;
using UniversalStrategyCore.TacticalCombat.Squad.FSM;
using UniversalStrategyCore.TacticalCombat.Unit;

namespace UniversalStrategyCore.TacticalCombat;

public class TacticalSquad
{
    public int Id { get; }
    public TacticalUnit[] TacticalUnits { get; }
    public SquadMovementComponent MovementComponent { get; }

    private readonly UnitTemplate _unitTemplate;
    private readonly int _unitsCount;

    public TacticalSquad(int id, UnitTemplate unitTemplate, int unitsCount)
    {
        Id = id;
        _unitTemplate = unitTemplate;
        _unitsCount = unitsCount;
        TacticalUnits = new TacticalUnit[unitsCount];
        MovementComponent = new SquadMovementComponent(this);
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        for (int i = 0; i < TacticalUnits.Length; i++)
        {
            TacticalUnits[i] = new TacticalUnit { Id = i + 1, Position = new Vector2(5f, 5f), Speed = _unitTemplate.Speed };
        }
        Console.WriteLine($"Отряд: {Id}, инициализировал юнитов с типом: {_unitTemplate.UnitType}, в количестве: {_unitsCount}");
    }
}