namespace UniversalStrategyCore.ConstructionSystem.Data;

public class ConstructionOrder(BuildingTemplate building)
{
    public BuildingTemplate Building { get; init; } = building;
    public int TurnsLeft = building.ConstructionTurns;
    public bool IsFinished => TurnsLeft <= 0;
    public void TickTurn() => TurnsLeft -= 1;
}