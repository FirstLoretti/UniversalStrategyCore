using UniversalStrategyCore.TacticalCombat.Entity;

namespace UniversalStrategyCore.TacticalCombat.FSM;

public class SquadStateAttacking(TacticalSquad squad) : ISquadState
{
    public void Enter()
    {
        Console.WriteLine($"Отряд: {squad.Id} вошёл в состояние Attacking");
    }

    public void Exit()
    {
        Console.WriteLine($"Отряд: {squad.Id} вышел из состояния Attacking");
    }

    public void Update(float deltaTime)
    {
        
    }
}