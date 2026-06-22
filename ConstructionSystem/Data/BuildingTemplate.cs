using UniversalStrategyCore.EconomicSystem;

namespace UniversalStrategyCore.ConstructionSystem.Data;

public record BuildingTemplate(
    string Id,
    string DisplayName,
    int ConstructionTurns,
    Dictionary<GameResourceType, int> Cost
);