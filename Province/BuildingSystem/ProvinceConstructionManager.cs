namespace UniversalStrategyCore.Province.BuildingSystem;

public class ProvinceConstructionManager
{
    public event Action? BuildingConstructed;
    private readonly Dictionary<ProvinceTemplate, List<ConstructionOrder>> _provinceToConstructionOrders = [];

    public void OnTurnEnd(ProvinceTemplate provinceTemplate)
    {
        if (_provinceToConstructionOrders.TryGetValue(provinceTemplate, out var constructionOrders))
        {
            foreach (var constructionOrder in constructionOrders)
            {
                constructionOrder.TickTurn();
                if (constructionOrder.IsFinished)
                {
                    BuildingConstructed?.Invoke();
                    Console.WriteLine($"Здание: {constructionOrder.BuildingTemplate.DisplayName} в провинции: {provinceTemplate.Name} построено.");
                }
            }
            constructionOrders.RemoveAll(order => order.IsFinished);
            if(constructionOrders.Count == 0)
            {
                _provinceToConstructionOrders.Remove(provinceTemplate);
            }
        }
    }

    public void AddConstructionOrder(ProvinceTemplate province, ConstructionOrder constructionOrder)
    {
        if (!_provinceToConstructionOrders.TryGetValue(province, out var constructionOrders))
        {
            constructionOrders = [];
            _provinceToConstructionOrders.Add(province, constructionOrders);
        }

        constructionOrders.Add(constructionOrder);
        Console.WriteLine(
            $"[ProvinceConstructionManager] " +
            $"Здание: {constructionOrder.BuildingTemplate.DisplayName} " +
            $"добавлено в стройку провинции: {province.Name}. " +
            $"Время строительства: {constructionOrder.TurnsLeft}."
        );
    }
}