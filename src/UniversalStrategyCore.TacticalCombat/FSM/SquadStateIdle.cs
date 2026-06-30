using UniversalStrategyCore.TacticalCombat.Entity;

namespace UniversalStrategyCore.TacticalCombat.FSM;

public class SquadStateIdle(TacticalSquad squad) : ISquadState
{
    public void Enter()
    {
        Console.WriteLine($"Отряд: {squad.Id} вошёл в состояние Idle");
    }

    public void Exit()
    {
        Console.WriteLine($"Отряд: {squad.Id} вышел из состояния Idle");
    }

    public void Update(float deltaTime)
    {
        
    }
}