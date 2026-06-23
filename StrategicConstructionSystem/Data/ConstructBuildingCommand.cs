using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public record ConstructBuildingCommand(
    FactionId FactionId,
    ProvinceId ProvinceId,
    ConstructionOrder ConstructionOrder
): IGameCommand;
