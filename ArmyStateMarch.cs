using System.Numerics;

namespace InsideTheWar.Armies;

public class ArmyStateMarch : IArmyState
{
    public string Name { get; init; } = "March";

    public void MoveTo(Army army, Vector2 destination)
    {
        Console.WriteLine("$ Армия на марше к {destination}");
    }

    public void TurnEndPenalties(Army army)
    {
        Console.WriteLine("Нет штрафов при марше");
    }
}