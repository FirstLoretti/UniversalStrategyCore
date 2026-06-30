using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.TacticalCombat;

public interface IAttackable
{
    public FactionId FactionHolder { get; }
    public bool IsAlive { get; }
    public int TakeDamage(int amount);
}