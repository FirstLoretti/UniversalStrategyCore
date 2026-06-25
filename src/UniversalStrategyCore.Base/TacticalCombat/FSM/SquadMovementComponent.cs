using System.Numerics;
using UniversalStrategyCore.TacticalCombat.Entity;

namespace UniversalStrategyCore.TacticalCombat.FSM;

public class SquadMovementComponent(TacticalSquad tacticalSquad)
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
        var units = tacticalSquad.TacticalUnits;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].Destination = point;
        }
        ChangeState(new SquadStateMoving(tacticalSquad));
#if DEBUG
        Console.WriteLine($"Приказ отряду: {tacticalSquad.Id} MoveTo: {point}.");
#endif
    }

    public void Stop()
    {
        var units = tacticalSquad.TacticalUnits;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].Position = units[i].Destination;
        }
        Console.WriteLine($"Юниты отряда: {tacticalSquad.Id}, остановились.");
    }
}