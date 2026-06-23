using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public class ProvinceConstructionManager : IProvinceConstructionManager
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
                }
            }
            orders.RemoveAll(order => order.IsFinished);
            if (orders.Count == 0)
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
    }

    public Result<bool> RemoveConstructionOrder(ProvinceId id, ConstructionOrder order)
    {
        if (_idToConstructionOrders.TryGetValue(id, out var orders))
        {
            if (!orders.Remove(order))
            {
                return Error.NotFound(order.Building.Id, nameof(_idToConstructionOrders));
            }
            return true;
        }
        return Error.NotFound(id, nameof(_idToConstructionOrders));
    }
}