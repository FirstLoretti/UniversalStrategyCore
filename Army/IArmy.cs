using UniversalStrategyCore.Share.Type;
using UniversalStrategyCore.Units;

namespace UniversalStrategyCore.Armies;

public interface IArmy
{
    public int Id { get; }
    public FactionId FactionId { get; }
    public UnitType UnitType { get; }
    public int UnitsCount { get; }
    public ArmyStrategicStats Stats { get; }

}