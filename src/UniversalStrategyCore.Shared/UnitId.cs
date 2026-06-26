namespace UniversalStrategyCore.Shared;

public readonly record struct UnitId(string Value)
{
    public static implicit operator UnitId(string value) => new(value);
}