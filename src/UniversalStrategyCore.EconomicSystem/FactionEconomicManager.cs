using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.EconomicSystem;

public class FactionEconomicManager(IFactionTable factionTable): IFactionEconomicManager
{
    public void ApplyTransaction(EconomicTransactionCommand transaction)
    {
        var faction = factionTable.GetFaction(transaction.FactionId);
        foreach (var resource in transaction.Amount)
        {
            faction.ResourceAmount[resource.Key] -= resource.Value;
        }
    }

    public void ReturnTransaction(EconomicTransactionCommand transaction)
    {
        var faction = factionTable.GetFaction(transaction.FactionId);
        foreach (var resource in transaction.Amount)
        {
            faction.ResourceAmount[resource.Key] += resource.Value;
        }
    }
}