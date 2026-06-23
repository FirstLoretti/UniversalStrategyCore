using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public class ProvinceConstructionManager: IProvinceConstructionManager
{
    public event Action? BuildingConstructed;
    private readonly Dictionary<ProvinceId, List<ConstructionOrder>> _idToConstructionOrders = [];

    public void OnTurnEnd(ProvinceId id)
    {
        if (_idToConstructionOrders.TryGetValue(id, out var orders))
        {
            foreach (var order in orders)
            {
                order.TickTurn();
                if (order.IsFinished)
                {
                    BuildingConstructed?.Invoke();
                    Console.WriteLine(
                        $"[{nameof(ProvinceConstructionManager)}]Здание: {order.Building.DisplayName} в провинции: {id} построено."
                    );
                }
            }
            orders.RemoveAll(order => order.IsFinished);
            if(orders.Count == 0)
            {
                _idToConstructionOrders.Remove(id);
            }
        }
    }

    public void AddConstructionOrder(ProvinceId id, ConstructionOrder order)
    {
        if (!_idToConstructionOrders.TryGetValue(id, out var constructionOrders))
        {
            constructionOrders = [];
            _idToConstructionOrders.Add(id, constructionOrders);
        }

        constructionOrders.Add(order);
        Console.WriteLine(
            $"[ProvinceConstructionManager] " +
            $"Здание: {order.Building.DisplayName} " +
            $"добавлено в стройку провинции: {id}. " +
            $"Время строительства: {order.TurnsLeft}."
        );
    }

    public void RemoveConstructionOrder(ProvinceId id, ConstructionOrder order)
    {
        if (_idToConstructionOrders.ContainsKey(id))
        {
            _idToConstructionOrders[id].Remove(order);
        }
        else
        {
            throw new Exception("Заказа нет в словаре");
        }
    }
}