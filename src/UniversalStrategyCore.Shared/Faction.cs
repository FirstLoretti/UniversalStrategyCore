namespace UniversalStrategyCore.Shared;

public record Faction(
    FactionId Id,
    string DisplayName,
    Dictionary<GameResourceType, int> ResourceAmount
);