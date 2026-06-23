namespace UniversalStrategyCore.Shared;

public record FactionTemplate(FactionId Id, string DisplayName, Dictionary<GameResourceType, int> ResourceAmount);