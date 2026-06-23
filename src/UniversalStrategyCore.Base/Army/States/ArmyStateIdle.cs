using System.Numerics;

namespace UniversalStrategyCore.Armies.States;

public class ArmyStateIdle : IArmyState
{
    public string Name { get; init;} = "Idle";

    public void MoveTo(Army army, Vector2 destination)
    {
        Console.WriteLine("Армия бездействует");
    }

    public void ApplyTurnEndPenalties(Army army)
    {
        Console.WriteLine("Нет штрафов в режиме ожидания");
    }
}