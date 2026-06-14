namespace UniversalStrategyCore.Province.BuildingSystem;

public record BuildingTemplate(
    string Id,
    string DisplayName,
    int ConstructionTurns,
    int WoodCost
);