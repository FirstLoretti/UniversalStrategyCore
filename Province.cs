using InsideTheWar.Buildings;

namespace InsideTheWar.Provinces;

class Province(int id, string name)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;

    private List<ConstructionOrder> _constructionOrders = [];

    public void AddConstructionOrder(BuildingType buildingType, int turns)
    {
        ConstructionOrder constructionOrder = new(buildingType, turns);
        _constructionOrders.Add(constructionOrder);
    }

    public void OnTurnEnd()
    {
        foreach (var construction in _constructionOrders)
        {
            construction.TickTurn();
        }

        var finishedConstructions = _constructionOrders.Where(c => c.IsFinished).ToList();
        PrintFinishedConstruction(finishedConstructions);
        RemoveFromConstructionOrders(finishedConstructions);
    }

    private void PrintFinishedConstruction(List<ConstructionOrder> constructionOrders)
    {
        foreach (var construction in constructionOrders)
        {
            Console.WriteLine($"{construction.BuildingType} is finished");
        }
    }

    private void RemoveFromConstructionOrders(List<ConstructionOrder> constructionOrders)
    {
        _constructionOrders.RemoveAll(c => constructionOrders.Contains(c));
    }
}