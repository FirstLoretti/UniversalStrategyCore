using System.Numerics;
using UniversalStrategyCore.TacticalCombat.Entity;
using UniversalStrategyCore.TacticalCombat.FSM;

namespace UniversalStrategyCore.TacticalCombat.Component;

public class SquadMovementComponent(TacticalSquad squad)
{
    private ISquadState _currentState = new SquadStateEmpty();

    public void ChangeState(ISquadState squadState)
    {
        _currentState.Exit();
        _currentState = squadState;
        _currentState.Enter();
    }

    public void Update(float deltaTime)
    {
        _currentState.Update(deltaTime);
    }

    public void MoveTo(Vector2 point)
    {
        var units = squad.Units;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].Destination = point;
        }
        ChangeState(new SquadStateMoving(squad));
#if DEBUG
        Console.WriteLine($"Приказ отряду: {squad.Id} MoveTo: {point}.");
#endif
    }

    public void Stop()
    {
        var units = squad.Units;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].Position = units[i].Destination;
        }
#if DEBUG
        Console.WriteLine($"Юниты отряда: {squad.Id}, остановились.");
#endif
    }
}