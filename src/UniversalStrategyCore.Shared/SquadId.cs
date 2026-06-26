namespace UniversalStrategyCore.Shared;

public readonly record struct SquadId(string Value)
{
    public static implicit operator SquadId(string value) => new(value);
}