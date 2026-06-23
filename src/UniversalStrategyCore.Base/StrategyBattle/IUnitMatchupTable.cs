using UniversalStrategyCore.Units;

namespace UniversalStrategyCore.StrategyBattle;

public interface IUnitMatchupTable
{
    public float GetUnitTypeAdvantage(UnitType attacker, UnitType defender);
}