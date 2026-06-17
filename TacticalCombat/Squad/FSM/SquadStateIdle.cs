namespace UniversalStrategyCore.TacticalCombat.Squad.FSM;

public class SquadStateIdle(TacticalSquad tacticalSquad) : ISquadState
{
    public void Enter()
    {
        Console.WriteLine($"Отряд: {tacticalSquad.Id} вошёл в состояние Idle");
    }

    public void Exit()
    {
        Console.WriteLine($"Отряд: {tacticalSquad.Id} вышел из состояния Idle");
    }

    public void Update(float deltaTime)
    {
        
    }
}