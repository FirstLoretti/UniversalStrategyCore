using UniversalStrategyCore.Factions;

namespace UniversalStrategyCore.EconomicSystem;

public record EconomicTransactionCommand(
    Guid Id,
    FactionTemplate Faction,
    EconomicTransactionType Type,
    Dictionary<GameResourceType, int> Amount,
    DateTime Time
): IGameCommand;