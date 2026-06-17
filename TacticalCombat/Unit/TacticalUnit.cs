using System.Numerics;

namespace UniversalStrategyCore.TacticalCombat.Unit;

public struct TacticalUnit
{
    public required int Id { get; init; }
    public required Vector2 Position { get; set; }
    public Vector2 Destination { get; set; }
    public required float Speed { get; set;}
}