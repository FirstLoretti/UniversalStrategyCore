namespace UniversalStrategyCore.Shared;

public readonly record struct BuildingId(string Value)
{
    public static implicit operator BuildingId(string value) => new(value);
}