using InsideTheWar.Factions;
using InsideTheWar.Units;

namespace InsideTheWar.Battle;

public class Army(int id, FactionName factionName, UnitType unitType, int unitsCount)
{
    public int Id {get;private set;} = id;
    public FactionName FactionName { get; private set; } = factionName;
    public UnitType UnitType {get; private set;} = unitType;
    public int UnitsCount { get; private set; } = unitsCount;
    public bool IsDestroyed => UnitsCount <= 0;

    public void DestroyAllUnits()
    {
        UnitsCount = 0;
    }

    public void TakeCasualties(int units)
    {
        UnitsCount -= units;
    }
}