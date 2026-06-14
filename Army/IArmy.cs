using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Units;

namespace UniversalStrategyCore.Armies;

public interface IArmy
{
    public int Id { get; }
    public FactionName FactionName { get; }
    public UnitType UnitType { get; }
    public int UnitsCount { get; }
    public ArmyStrategicStats Stats { get; }

}