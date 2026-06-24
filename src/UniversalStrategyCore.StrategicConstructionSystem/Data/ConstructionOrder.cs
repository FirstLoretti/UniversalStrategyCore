namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public class ConstructionOrder(Building building)
{
    public Building Building { get; init; } = building;
    public int TurnsLeft = building.ConstructionTurns;
    public bool IsFinished => TurnsLeft <= 0;
    public void TickTurn() => TurnsLeft -= 1;
}