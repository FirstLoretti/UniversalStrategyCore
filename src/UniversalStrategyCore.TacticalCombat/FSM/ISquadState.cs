namespace UniversalStrategyCore.TacticalCombat.FSM;

public interface ISquadState
{
    public void Enter();
    public void Update(float deltaTime);
    public void Exit();
}