using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.EconomicSystem;

public interface IFactionEconomicManager
{
    public Result<bool> ApplyTransaction(EconomicTransactionCommand transaction);
    public void ReturnTransaction(EconomicTransactionCommand transaction);
}