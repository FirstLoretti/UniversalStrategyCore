namespace UniversalStrategyCore.EconomicSystem;

public class FactionEconomicManager : IFactionEconomicManager
{
    public void ApplyTransaction(EconomicTransactionCommand transaction)
    {
        foreach (var resource in transaction.Amount)
        {
            transaction.Faction.ResourceAmount[resource.Key] -= resource.Value;
        }
    }

    public void ReturnTransaction(EconomicTransactionCommand transaction)
    {
        foreach (var resource in transaction.Amount)
        {
            transaction.Faction.ResourceAmount[resource.Key] += resource.Value;
        }
    }
}