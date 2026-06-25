namespace UniversalStrategyCore.Shared;

public readonly record struct SquadId
{
    private readonly string _value;

    public string Value => _value ?? "empty_id";

    public SquadId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Id не может быть пустым", nameof(value));
        
        _value = value.Trim().ToLowerInvariant();
    }

    public override string ToString() => _value;

    public static implicit operator SquadId(string value) => new(value);
}