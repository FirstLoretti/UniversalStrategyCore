using System.Numerics;

namespace InsideTheWar.Armies;

public interface IArmyState
{
    public string Name { get; init; }
    public void MoveTo(Army army, Vector2 destination);
    public void TurnEndPenalties(Army army);
}