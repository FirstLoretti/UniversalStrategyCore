using System.Numerics;
using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Component;

namespace UniversalStrategyCore.TacticalCombat.Entity;

public class TacticalSquad : IAttackable
{
    public int Id { get; }
    public FactionId FactionHolder {get;}
    public TacticalUnit[] Units { get; }
    public SquadMovementComponent MovementComponent { get; }
    public SquadBattleComponent BattleComponent { get; }
    public bool IsAlive => _isAlive;

    private readonly IExperienceSquadTable _experienceTable;
    private readonly Unit _unit;
    private bool _isAlive => _unitsCount > 0;
    private int _unitsCount;
    private int _experience;
    private int _level;

    public TacticalSquad(int id, Unit unit, int unitsCount, IExperienceSquadTable experienceSquadTable)
    {
        Id = id;
        _unit = unit;
        Units = new TacticalUnit[unitsCount];
        MovementComponent = new SquadMovementComponent(this);
        BattleComponent = new SquadBattleComponent(this);
        _experienceTable = experienceSquadTable;
        _unitsCount = unitsCount;
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        for (int i = 0; i < Units.Length; i++)
        {
            Units[i] = new TacticalUnit { Id = i + 1, Position = new Vector2(5f, 5f), Speed = _unit.Speed };
        }
    }

    public int CalculateCurrentDamage()
    {
        if (!_isAlive) return 0;

        var damage = _unit.Damage * _unitsCount;
        var levelMultiplier = 1.0f + _level * 0.1f;

        return (int)MathF.Ceiling(damage + levelMultiplier);
    }

    public int TakeDamage(int amount)
    {
        if (!_isAlive) return 0;

        var casualties = int.Min(amount / _unit.Health, _unitsCount);
        _unitsCount -= casualties;
        
        return casualties * _unit.ExpKillReward;
    }

    public Result<bool> AddExperience(int amount)
    {
        if (!_isAlive) return Error.SquadDestroyed(Id);

        _experience += int.Max(0, amount);
        _level = _experienceTable.GetLevel(_experience);

        return true;
    }

    public void Counterattack(IAttackable attacker)
    {
        BattleComponent.Attack(attacker, true);
    }
}