using UniversalStrategyCore.TacticalCombat.Entity;
using UniversalStrategyCore.TacticalCombat.FSM;

namespace UniversalStrategyCore.TacticalCombat.Component;

public class SquadBattleComponent(TacticalSquad squad)
{
    private ISquadState _currentState = new SquadStateEmpty();

    public void ChangeState(ISquadState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update(float deltaTime)
    {
        _currentState.Update(deltaTime);
    }

    public void Attack(IAttackable target, bool isCounterattack = false)
    {
        if(!target.IsAlive || target.FactionHolder == squad.FactionHolder) return;

        var expReward = target.TakeDamage(squad.CalculateCurrentDamage());
        squad.AddExperience(expReward);

        if (isCounterattack) return;

        if (target.IsAlive && target is ICanCounterattack defender)
        {
            defender.Counterattack(squad);
        }
    }
}