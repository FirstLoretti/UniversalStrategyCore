namespace UniversalStrategyCore.Shared;

public readonly record struct SquadId
{
    public readonly string Value => _value ?? "empty_id";
    private readonly string _value;

    public SquadId(string value) => _value = value;
    
    public static implicit operator SquadId(string value) => new(value);
}