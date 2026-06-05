using InsideTheWar.Armies;

namespace InsideTheWar.Battle;

public interface IBattleSolver
{
    public BattleReport ResolveBattle(Army attacker, Army defender);
}