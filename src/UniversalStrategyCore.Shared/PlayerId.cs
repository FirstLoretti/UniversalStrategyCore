namespace UniversalStrategyCore.Shared;

public readonly record struct PlayerId
{
    public readonly string Value => _value ?? "empty_id";
    private readonly string _value;

    public PlayerId(string value) => _value = value;

    public static implicit operator PlayerId(string value) => new(value);
}