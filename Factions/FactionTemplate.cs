using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.Factions;

public record FactionTemplate(FactionId Id, string DisplayName, Dictionary<GameResourceType, int> ResourceAmount);