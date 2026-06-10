using UniversalStrategyCore.Armies;

namespace UniversalStrategyCore.StrategyBattle;

public class BattleReport
{
    private Army? _victoriousArmy;
    private Army? _defeatedArmy;
    private int _victoriousArmyCasualties;
    private int _defeatedArmyCasualties;
    private int _victoriousArmyPower;
    private int _defeatedArmyPower;
    private bool _isDraw;

    private BattleReport(Army? victoriousArmy, Army? defeatedArmy, int victoriousArmyCasualties, int defeatedArmyCasualties, int victoriousArmyPower, int defeatedArmyPower, bool isDraw)
    {
        _victoriousArmy = victoriousArmy;
        _defeatedArmy = defeatedArmy;
        _victoriousArmyCasualties = victoriousArmyCasualties;
        _defeatedArmyCasualties = defeatedArmyCasualties;
        _victoriousArmyPower = victoriousArmyPower;
        _defeatedArmyPower = defeatedArmyPower;
        _isDraw = isDraw;
    }

    public static BattleReport CreateVictoryReport(Army victoriousArmy, Army defeatedArmy, int victoriousArmyCasualties, int defeatedArmyCasualties, int victoriousArmyPower, int defeatedArmyPower)
    {
        return new BattleReport(victoriousArmy, defeatedArmy, victoriousArmyCasualties, defeatedArmyCasualties, victoriousArmyPower, defeatedArmyPower, isDraw: false);
    }

    public static BattleReport CreateDrawReport()
    {
        return new BattleReport(null, null, 0, 0, 0, 0, isDraw: true);
    }

    public void Print()
    {
        if (_isDraw == true)
        {
            Console.WriteLine($"Draw");
            return;
        }

        Console.WriteLine(
            $"Victorious army {_victoriousArmy!.Id} of the faction {_victoriousArmy!.FactionName} " +
            $"take casualties {_victoriousArmyCasualties}. Units alive: {_victoriousArmy!.UnitsCount}. Power: {_victoriousArmyPower}");
        Console.WriteLine(
            $"Defeated army {_defeatedArmy!.Id} of the faction {_defeatedArmy!.FactionName} " +
            $"take casualties {_defeatedArmyCasualties}. Units alive: {_defeatedArmy!.UnitsCount}. Power: {_defeatedArmyPower}");
    }
}