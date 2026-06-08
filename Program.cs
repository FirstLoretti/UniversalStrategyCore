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
using InsideTheWar.AI.Faction;
using InsideTheWar.PlayerRegistrar;
using InsideTheWar.Bootstrap;
using Microsoft.Extensions.DependencyInjection;

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
        GameBootstrap gameBootstrap = new();
        var provinceManager = gameBootstrap.GameServices.GetRequiredService<ProvinceManager>();
        var turnManager = gameBootstrap.GameServices.GetRequiredService<TurnManager>();
        var playerHolder = gameBootstrap.GameServices.GetRequiredService<PlayerHolder>();

        Player player1 = new("Loretty", false);
        Player player2 = new("AI", true);
        playerHolder.RegisterPlayer(player1);
        playerHolder.RegisterPlayer(player2);

        provinceManager.RegisterProvince(new(1, "London"), player1.Name);
        provinceManager.RegisterProvince(new(2, "Paris"), player2.Name);

        turnManager.TurnEnd(player1.Name);

        // paris.AddConstructionOrder(BuildingType.Farm, 2);
        // paris.AddConstructionOrder(BuildingType.Barrack, 3);
        // Console.WriteLine("Turn 1");
        // turnManager.TurnEnd();
        // Console.WriteLine("Turn 2");
        // turnManager.TurnEnd();
        // Console.WriteLine("Turn 3");
        // turnManager.TurnEnd();
        ///
        // UnitMatchupTable unitMatchupTable = new();
        // AutoBattleManager autoBattleManager = new();
        // FieldBattleSolveStrategy fieldBattleSolveStrategy = new(unitMatchupTable);
        // SiegeBattleSolveStrategy siegeBattleSolveStrategy = new(unitMatchupTable);
        // ArmyManager armyManager = new();

        // Army attacker = new(1, FactionName.France, UnitType.Cavalry, 750, new ArmyStats());
        // Army defender = new(2, FactionName.England, UnitType.Infantry, 1000, new ArmyStats());
        // armyManager.RegisterArmy(attacker);
        // armyManager.RegisterArmy(defender);
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
        // MapWeatherPenaltiesTable mapWeatherPenaltiesTable = new();
        // ArmyWeatherMediator armyWeatherMediator = new(armyManager, mapWeatherPenaltiesTable);
        // armyWeatherMediator.CurrentWeatherImpactOnArmies(MapWeatherType.Snow);
        ///
        AIFaction aIFaction = new(FactionName.France);
    }
}