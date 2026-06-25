using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore;

public struct UnitMatchup
{
    public UnitType Attacker { get; }
    public UnitType Defender { get; }
    public float Advantage { get; }

    public UnitMatchup(UnitType attacker, UnitType defender, float advantage)
    {
        Attacker = attacker;
        Defender = defender;
        Advantage = advantage;
    }
}