using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.EconomicSystem;

public class FactionEconomicManager(IFactionTable factionTable) : IFactionEconomicManager
{
    public Result<bool> ApplyTransaction(EconomicTransactionCommand transaction)
    {
        var faction = factionTable.GetFaction(transaction.FactionId);
        Dictionary<GameResourceType, int> deficitResources = [];
        foreach (var (resource, amount) in transaction.Amount)
        {
            var currentAmount = faction.ResourceAmount.GetValueOrDefault(resource, 0);
            var finalAmount = currentAmount - amount;
            if (finalAmount < 0) deficitResources.Add(resource, Math.Abs(finalAmount));
        }
        if (deficitResources.Count == 0)
        {
            foreach (var (resource, amount) in transaction.Amount)
            {
                faction.ResourceAmount[resource] -= amount;
            }
            return true;
        }
        return Error.NotEnoughtResources(deficitResources);
    }

    public void ReturnTransaction(EconomicTransactionCommand transaction)
    {
        var faction = factionTable.GetFaction(transaction.FactionId);
        foreach (var (resource, amount) in transaction.Amount)
        {
            faction.ResourceAmount[resource] += amount;
        }
    }
}