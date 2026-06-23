namespace UniversalStrategyCore.Share.Type;

public readonly record struct BuildingId
{
    private readonly string _value;

    public BuildingId(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Id не может быть пустым"); }
        _value = value.Trim().ToLowerInvariant();
    }
    public static implicit operator BuildingId(string value) => new(value);
    public override string ToString() => _value;
}