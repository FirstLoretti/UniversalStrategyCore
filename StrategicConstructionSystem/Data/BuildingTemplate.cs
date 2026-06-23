using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public record BuildingTemplate(
    BuildingId Id,
    string DisplayName,
    int ConstructionTurns,
    Dictionary<GameResourceType, int> Cost
);