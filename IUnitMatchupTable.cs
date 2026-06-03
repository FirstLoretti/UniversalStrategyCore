using InsideTheWar.Units;

namespace InsideTheWar.Battle;

public interface IUnitMatchupTable
{
    public float GetUnitTypeAdvantage(UnitType attacker, UnitType defender);
}