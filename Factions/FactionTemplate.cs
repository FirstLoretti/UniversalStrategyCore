using UniversalStrategyCore.EconomicSystem;

namespace UniversalStrategyCore.Factions;

public record FactionTemplate(FactionName Name, Dictionary<GameResourceType, int> ResourceAmount);