namespace UniversalStrategyCore.Shared;

public readonly record struct PlayerId
{
    private readonly string _value;

    public PlayerId(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Поле не может быть пустым");

        _value = value.Trim().ToLowerInvariant();
    }

    public static implicit operator PlayerId(string value) => new(value);
    public override string ToString() => _value;
}