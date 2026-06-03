namespace InsideTheWar.Battle;

public class AutoBattleManager()
{
    public BattleReport ExecuteBattle(Army attacker, Army defender, IBattleSolver battleSolver)
    {
        var battleReport = battleSolver.ResolveBattle(attacker, defender);
        return battleReport;
    }
}