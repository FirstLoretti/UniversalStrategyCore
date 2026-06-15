namespace UniversalStrategyCore.TacticalCombat;

public record struct Vector2D(float X, float Y)
{
    public readonly float SquareDistanceTo(in Vector2D point)
    {
        var xDistance = point.X - X;
        var yDistance = point.Y - Y;
        var distanceTo = xDistance * xDistance + yDistance * yDistance;
        return distanceTo;
    }

    public readonly float DistanceTo(in Vector2D point) => MathF.Sqrt(SquareDistanceTo(point));
}