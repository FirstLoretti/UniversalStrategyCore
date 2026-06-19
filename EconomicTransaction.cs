using UniversalStrategyCore.Factions;

namespace UniversalStrategyCore;

public record EconomicTransaction(
    Guid Id,
    FactionTemplate Faction,
    EconomicTransactionType Type,
    Dictionary<ResourceType, int> Amount,
    DateTime Time
);