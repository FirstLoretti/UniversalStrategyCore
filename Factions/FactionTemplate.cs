using UniversalStrategyCore.FactionEconomicSystem;

namespace UniversalStrategyCore.Factions;

public record FactionTemplate(FactionName Name, Dictionary<ResourceType, int> ResourceAmount);