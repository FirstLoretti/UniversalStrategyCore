using System.Numerics;

namespace UniversalStrategyCore.Armies.States;

public class ArmyStateMarch : IArmyState
{
    public string Name { get; init; } = "March";

    public void MoveTo(Army army, Vector2 destination)
    {
        Console.WriteLine("$ Армия на марше к {destination}");
    }

    public void ApplyTurnEndPenalties(Army army)
    {
        Console.WriteLine("Нет штрафов при марше");
    }
}