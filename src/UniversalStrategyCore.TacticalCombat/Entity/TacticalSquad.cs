using System.Numerics;
using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Component;

namespace UniversalStrategyCore.TacticalCombat.Entity;

public class TacticalSquad : IAttackable, ICanCounterattack
{
    public int Number { get; }
    public FactionId FactionHolder { get; }
    public TacticalUnit[] Units { get; }
    public int UnitsCount { get; private set; }
    public SquadMovementComponent MovementComponent { get; }
    public SquadBattleComponent BattleComponent { get; }
    public bool IsAlive => UnitsCount > 0;
    public int Experience { get; private set; }
    public int Level { get; private set; }

    private readonly IExperienceSquadTable _experienceTable;
    private readonly Unit _unit;

    public TacticalSquad(
        int number,
        FactionId factionHolder,
        Unit unit,
        int unitsCount,
        IExperienceSquadTable experienceSquadTable)
    {
        Number = number;
        _unit = unit;
        Units = new TacticalUnit[unitsCount];
        MovementComponent = new SquadMovementComponent(this);
        BattleComponent = new SquadBattleComponent(this);
        _experienceTable = experienceSquadTable;
        UnitsCount = unitsCount;
        FactionHolder = factionHolder;
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        for (int i = 0; i < Units.Length; i++)
        {
            Units[i] = new TacticalUnit { Id = i + 1, Position = new Vector2(5f, 5f), Speed = _unit.Speed };
        }
    }

    public void Counterattack(IAttackable attacker) => BattleComponent.Attack(attacker, true);

    public int CalculateCurrentDamage()
    {
        if (!IsAlive) return 0;

        var baseDamage = _unit.Damage * UnitsCount;
        var levelMultiplier = 1.0f + Level * 0.1f;

        return (int)MathF.Ceiling(baseDamage * levelMultiplier);
    }

    public int TakeDamage(int amount)
    {
        if (!IsAlive) return 0;

        var casualties = int.Min(amount / _unit.Health, UnitsCount);
        UnitsCount -= casualties;

        return casualties * _unit.ExpKillReward;
    }

    public Result<bool> AddExperience(int amount)
    {
        if (!IsAlive) return Error.SquadDestroyed(Number);

        Experience += int.Max(0, amount);
        Level = _experienceTable.GetLevel(Experience);

        return true;
    }
}