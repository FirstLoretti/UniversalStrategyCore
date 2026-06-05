using InsideTheWar.Buildings;
using InsideTheWar.Map;
using InsideTheWar.Battle;
using InsideTheWar.Factions;
using InsideTheWar.Units;
using InsideTheWar.Provinces;
using InsideTheWar.Managers;
using InsideTheWar.Armies;
using InsideTheWar.Mediators;
using InsideTheWar.Map.WeatherLogic;

class Program
{
    public static void Main(string[] args)
    {
        GameSession session = new();
        session.Start();
    }
}

class GameSession
{
    public void Start()
    {
        Province rome = new(1, "Rome");
        Province paris = new(2, "Paris");
        WorldMap worldMap = new();
        TurnManager turnManager = new();

        worldMap.AddProvince(rome);
        worldMap.AddProvince(paris);

        var provinceParis = worldMap.GetProvince(2);
        if (provinceParis != null)
        {
            turnManager.OnTurnEnded += provinceParis.OnTurnEnd;
        }

        // paris.AddConstructionOrder(BuildingType.Farm, 2);
        // paris.AddConstructionOrder(BuildingType.Barrack, 3);
        // Console.WriteLine("Turn 1");
        // turnManager.TurnEnd();
        // Console.WriteLine("Turn 2");
        // turnManager.TurnEnd();
        // Console.WriteLine("Turn 3");
        // turnManager.TurnEnd();
        ///
        UnitMatchupTable unitMatchupTable = new();
        AutoBattleManager autoBattleManager = new();
        FieldBattleSolveStrategy fieldBattleSolveStrategy = new(unitMatchupTable);
        SiegeBattleSolveStrategy siegeBattleSolveStrategy = new(unitMatchupTable);
        ArmyManager armyManager = new();

        Army attacker = new(1, FactionName.France, UnitType.Cavalry, 750, new ArmyStats());
        Army defender = new(2, FactionName.England, UnitType.Infantry, 1000, new ArmyStats());
        armyManager.RegisterArmy(attacker);
        armyManager.RegisterArmy(defender);
        //var battleReportField = autoBattleManager.ExecuteBattle(attacker, defender, fieldBattleSolveStrategy);
        //battleReportField.Print();
        // Console.WriteLine("SiegeBattle");
        // Army attacker2 = new(3, FactionName.France, UnitType.Cavalry, 750, armyStats);
        // Army defender2 = new(4, FactionName.England, UnitType.Infantry, 1000, armyStats);
        // var battleReportSiege = autoBattleManager.ExecuteBattle(attacker2, defender2, siegeBattleSolveStrategy);
        // battleReportSiege.Print();
        ///
        //turnManager.OnTurnEnded += attacker.OnTurnEnd;
        //attacker.ChangeState(new ArmyStateForcedMarch());
        //turnManager.TurnEnd();
        MapWeatherPenaltiesTable mapWeatherPenaltiesTable = new();
        ArmyWeatherMediator armyWeatherMediator = new(armyManager, mapWeatherPenaltiesTable);
        armyWeatherMediator.CurrentWeatherImpactOnArmies(MapWeatherType.Snow);
    }
}