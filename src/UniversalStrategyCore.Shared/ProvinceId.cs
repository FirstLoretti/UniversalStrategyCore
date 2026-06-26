namespace UniversalStrategyCore.Shared;

public readonly record struct ProvinceId
{
    public readonly string Value => _value ?? "empty_id";
    private readonly string _value;

    public ProvinceId(string value) => _value = value;
    
    public static implicit operator ProvinceId(string value) => new(value);
}