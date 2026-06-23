using UniversalStrategyCore.Shared;
using UniversalStrategyCore.Units;

namespace UniversalStrategyCore.Armies;

public class ArmyManager
{
    public Dictionary<int, Army> Armies { get; private set; } = [];

    private int _armyId;

    public Army CreateArmy(FactionId factionId, UnitType unitType, int unitsCount)
    {
        _armyId += 1;
        var armyStrategicStats = new ArmyStrategicStats();
        var army = new Army(_armyId, factionId, unitType, unitsCount, armyStrategicStats);
        Armies.TryAdd(army.Id, army);
        army.ArmyDestroyed += OnArmyDestroyed;
        return army;
    }

    public void OnArmyDestroyed(Army army)
    {
        Console.WriteLine($"Армия с id: {army.Id} удалена");
        army.ArmyDestroyed -= OnArmyDestroyed;
        Armies.Remove(army.Id);
    }
}