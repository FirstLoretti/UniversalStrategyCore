namespace UniversalStrategyCore.Shared;

public readonly record struct FactionId
{
    private readonly string _value;

    public FactionId(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Id не может быть пустым"); }
        _value = value.Trim().ToLowerInvariant();
    }
    public static implicit operator FactionId(string value) => new(value);
    public override string ToString() => _value;
}