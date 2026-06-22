using UniversalStrategyCore.ConstructionSystem.Data;

namespace UniversalStrategyCore.EconomicSystem;

public record ConstructionSystemTransactions
{
    private readonly Dictionary<int, Dictionary<ConstructBuildingCommand, EconomicTransactionCommand>> _idToCommands = [];
    private int _id;

    public void AddTransaction(ConstructBuildingCommand order, EconomicTransactionCommand transaction)
    {
        _id++;
        Dictionary<ConstructBuildingCommand, EconomicTransactionCommand> dictionary = new (){{order, transaction}};
        if(!_idToCommands.TryAdd(_id, dictionary))
        {
            throw new Exception("Ключ уже есть в словаре");
        }
    }

    public void RemoveTransaction(int id)
    {
       if(!_idToCommands.Remove(id))
        {
            throw new Exception("Ключа не было в словаре");
        }
    }
}