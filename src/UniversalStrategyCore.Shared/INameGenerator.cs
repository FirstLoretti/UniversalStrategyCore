namespace UniversalStrategyCore.Shared;

public interface INameGenerator
{
    public Result<string> GenerateName(FactionId id);
}