using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.EconomicSystem;

public record EconomicTransactionCommand(
    Guid Id,
    FactionId FactionId,
    EconomicTransactionType Type,
    Dictionary<GameResourceType, int> Amount,
    DateTime Time
): IGameCommand;