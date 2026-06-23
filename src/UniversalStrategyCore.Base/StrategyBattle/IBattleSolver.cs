using UniversalStrategyCore.Armies;

namespace UniversalStrategyCore.StrategyBattle;

public interface IBattleSolver
{
    public BattleReport ResolveBattle(Army attacker, Army defender);
}