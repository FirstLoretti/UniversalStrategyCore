namespace UniversalStrategyCore.Shared;

public readonly record struct BuildingId
{
    public readonly string Value => _value ?? "empty_id";
    private readonly string _value;

    public BuildingId(string value) => _value = value;
    
    public static implicit operator BuildingId(string value) => new(value);
}