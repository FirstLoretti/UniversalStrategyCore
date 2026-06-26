namespace UniversalStrategyCore.Shared;

public readonly record struct PlayerId(string Value)
{
    public static implicit operator PlayerId(string value) => new(value);
}