using InsideTheWar.GameMath;

namespace InsideTheWar.Battle;

public class FieldBattleSolveStrategy(IUnitMatchupTable unitMatchupTable) : IBattleSolver
{
    public BattleReport ResolveBattle(Army attacker, Army defender)
    {
        var advantage = unitMatchupTable.GetUnitTypeAdvantage(attacker.UnitType, defender.UnitType);
        var attackerPower = ArmyMath.CalculatePower(attacker.UnitsCount, advantage);
        var defenderPower = ArmyMath.CalculatePower(defender.UnitsCount);

        if (attackerPower > defenderPower)
        {
            var defenderInitialUnits = defender.UnitsCount;
            var army1Casualties = ArmyMath.CalculateRandomCasualties(attacker.UnitsCount);
            attacker.TakeCasualties(army1Casualties);
            defender.DestroyAllUnits();

            var battleReport = BattleReport.CreateVictoryReport(attacker, defender, army1Casualties, defenderInitialUnits, attackerPower, defenderPower);
            return battleReport;
        }
        else if (attackerPower < defenderPower)
        {
            var attackerInitialUnits = attacker.UnitsCount;
            var army2Casualties = ArmyMath.CalculateRandomCasualties(defender.UnitsCount);
            defender.TakeCasualties(army2Casualties);
            attacker.DestroyAllUnits();

            var battleReport = BattleReport.CreateVictoryReport(defender, attacker, army2Casualties, attackerInitialUnits, defenderPower, attackerPower);
            return battleReport;
        }
        else
        {
            attacker.DestroyAllUnits();
            defender.DestroyAllUnits();

            var battleReport = BattleReport.CreateDrawReport();
            return battleReport;
        }
    }
}