using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public record ConstructBuildingCommand(
    FactionId FactionId,
    ProvinceId ProvinceId,
    ConstructionOrder ConstructionOrder
): IGameCommand;
