using UniversalStrategyCore.TacticalCombat.Unit;

namespace UniversalStrategyCore.TacticalCombat;

public class TacticalSquad(UnitTemplate unitTemplate, int unitCount)
{   
    private readonly TacticalUnit[] _tacticalUnits = new TacticalUnit[unitCount];

    public void UnitsCount() => Console.WriteLine(_tacticalUnits.Length);
}