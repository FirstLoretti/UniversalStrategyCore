using UniversalStrategyCore.Armies;

namespace UniversalStrategyCore.StrategyBattle;

public class AutoBattleManager()
{
    public BattleReport ExecuteBattle(Army attacker, Army defender, IBattleSolver battleSolver)
    {
        var battleReport = battleSolver.ResolveBattle(attacker, defender);
        return battleReport;
    }
}