using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.ConstructionSystem.Logic;

public class ProvinceConstructionManager: IProvinceConstructionManager
{
    public event Action? BuildingConstructed;
    private readonly Dictionary<ProvinceTemplate, List<ConstructionOrder>> _provinceToConstructionOrders = [];

    public void OnTurnEnd(ProvinceTemplate province)
    {
        if (_provinceToConstructionOrders.TryGetValue(province, out var orders))
        {
            foreach (var order in orders)
            {
                order.TickTurn();
                if (order.IsFinished)
                {
                    BuildingConstructed?.Invoke();
                    Console.WriteLine($"Здание: {order.Building.DisplayName} в провинции: {province.Name} построено.");
                }
            }
            orders.RemoveAll(order => order.IsFinished);
            if(orders.Count == 0)
            {
                _provinceToConstructionOrders.Remove(province);
            }
        }
    }

    public void AddConstructionOrder(ProvinceTemplate province, ConstructionOrder order)
    {
        if (!_provinceToConstructionOrders.TryGetValue(province, out var constructionOrders))
        {
            constructionOrders = [];
            _provinceToConstructionOrders.Add(province, constructionOrders);
        }

        constructionOrders.Add(order);
        Console.WriteLine(
            $"[ProvinceConstructionManager] " +
            $"Здание: {order.Building.DisplayName} " +
            $"добавлено в стройку провинции: {province.Name}. " +
            $"Время строительства: {order.TurnsLeft}."
        );
    }

    public void RemoveConstructionOrder(ProvinceTemplate province, ConstructionOrder order)
    {
        if (_provinceToConstructionOrders.ContainsKey(province))
        {
            _provinceToConstructionOrders[province].Remove(order);
        }
        else
        {
            throw new Exception("Заказа нет в словаре");
        }
    }
}