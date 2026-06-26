namespace UniversalStrategyCore.Shared;

public readonly record struct UnitId
{
    public readonly string Value => _value ?? "empty_id";
    private readonly string _value;

    public UnitId(string value) => _value = value;
    
    public static implicit operator UnitId(string value) => new(value);
}