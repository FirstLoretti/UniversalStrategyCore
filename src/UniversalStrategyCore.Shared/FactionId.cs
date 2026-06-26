namespace UniversalStrategyCore.Shared;

public readonly record struct FactionId
{
    public readonly string Value => _value ?? "empty_id";
    private readonly string _value;

    public FactionId(string value) => _value = value;
    
    public static implicit operator FactionId(string value) => new(value);
}