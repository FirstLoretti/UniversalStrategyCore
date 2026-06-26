namespace UniversalStrategyCore.Shared;

public readonly record struct ProvinceId(string Value)
{
    public static implicit operator ProvinceId(string value) => new(value);
}