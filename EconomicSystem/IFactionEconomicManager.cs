namespace UniversalStrategyCore.EconomicSystem;

public interface IFactionEconomicManager
{
    public void ApplyTransaction(EconomicTransactionCommand transaction);
    public void ReturnTransaction(EconomicTransactionCommand transaction);
}