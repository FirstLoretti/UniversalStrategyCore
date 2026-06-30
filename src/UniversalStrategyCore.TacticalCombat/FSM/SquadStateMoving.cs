using System.Numerics;
using UniversalStrategyCore.TacticalCombat.Entity;

namespace UniversalStrategyCore.TacticalCombat.FSM;

public class SquadStateMoving(TacticalSquad squad) : ISquadState
{
    public void Enter()
    {
        Console.WriteLine($"Отряд: {squad.Number} вошёл в состояние Moving");
    }

    public void Exit()
    {
        Console.WriteLine($"Отряд: {squad.Number} вышел из состояния Moving");
    }

    public void Update(float deltaTime)
    {
        var units = squad.Units;
        for (int i = 0; i < units.Length; i++)
        {
            var unit = units[i];
            var squareDistance = Vector2.DistanceSquared(unit.Position, unit.Destination);
            var frameStep = unit.Speed * deltaTime;
            if (squareDistance < frameStep * frameStep)
            {
                unit.Position = unit.Destination;
#if DEBUG
                Console.WriteLine(
                    $"[SquadStateMoving] Юнит: {unit.Id} с целью: {unit.Destination} прибыл в точку назначения. " +
                    $"Текущая позиция: {unit.Destination}."
                );
#endif
            }
            else
            {
                var distanceVector = unit.Destination - unit.Position;
                var distance = MathF.Sqrt(squareDistance);
                var direction = distanceVector / distance;
                unit.Position += direction * frameStep;
            }
            units[i] = unit;
#if DEBUG
            Console.WriteLine($"[SquadStateMoving] Юнит: {unit.Id} прибыл в позицию: {unit.Position}.");
#endif
        }
    }
}