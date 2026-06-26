namespace UniversalStrategyCore.Shared;

public readonly record struct FactionId(string Value)
{
    public static implicit operator FactionId(string value) => new(value);
}