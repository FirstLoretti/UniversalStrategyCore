using System.Numerics;

namespace UniversalStrategyCore.Armies.States;

public interface IArmyState
{
    public string Name { get; init; }
    public void MoveTo(Army army, Vector2 destination);
    public void ApplyTurnEndPenalties(Army army);
}