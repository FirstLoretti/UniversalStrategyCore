namespace UniversalStrategyCore.Province.BuildingSystem;

public class ConstructionOrder(BuildingTemplate buildingTemplate)
{
    public BuildingTemplate BuildingTemplate { get; init; } = buildingTemplate;
    public int TurnsLeft = buildingTemplate.ConstructionTurns;
    public bool IsFinished => TurnsLeft <= 0;

    public void TickTurn() => TurnsLeft -= 1;
}