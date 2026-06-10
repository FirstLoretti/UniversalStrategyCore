namespace UniversalStrategyCore.Buildings;

class ConstructionOrder(BuildingType buildingType, int turns)
{
    public BuildingType BuildingType { get; private set; } = buildingType;
    public int TurnsLeft { get; private set; } = turns;
    public bool IsFinished => TurnsLeft <= 0;

    public void TickTurn() => TurnsLeft -= 1;
}