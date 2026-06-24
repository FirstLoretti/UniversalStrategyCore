using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public class ProvinceConstructionManager : IProvinceConstructionManager
{
    public event Action? BuildingConstructed;

    private readonly Dictionary<ProvinceId, List<ConstructionOrder>> _idToConstructionOrders = [];
    private readonly int _maxOrders = 5;

    public void OnTurnEnd(ProvinceId id)
    {
        if (_idToConstructionOrders.TryGetValue(id, out var orders))
        {
            foreach (var order in orders)
            {
                order.TickTurn();
                if (order.IsFinished) BuildingConstructed?.Invoke();
            }
            orders.RemoveAll(order => order.IsFinished);
        }
    }

    public Result<bool> AddConstructionOrder(ProvinceId id, ConstructionOrder order)
    {
        if (!_idToConstructionOrders.TryGetValue(id, out var constructionOrders))
        {
            constructionOrders = [];
            _idToConstructionOrders.Add(id, constructionOrders);
        }
        if (constructionOrders.Count < _maxOrders)
        {
            constructionOrders.Add(order);
            return true;
        }
        return false;
    }

    public Result<bool> RemoveConstructionOrder(ProvinceId id, ConstructionOrder order)
    {
        if (_idToConstructionOrders.TryGetValue(id, out var orders))
        {
            if (!orders.Remove(order))
                return Error.NotFound(order.Building.Id, nameof(_idToConstructionOrders));  
                
            return true;
        }
        return Error.NotFound(id, nameof(_idToConstructionOrders));
    }
}