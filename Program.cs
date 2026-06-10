using UniversalStrategyCore.Buildings;
using UniversalStrategyCore.Map;
using UniversalStrategyCore.StrategyBattle;
using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Units;
using UniversalStrategyCore.Provinces;
using UniversalStrategyCore.Managers;
using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.Map.WeatherLogic;
using UniversalStrategyCore.AI.Faction;
using UniversalStrategyCore.PlayerRegistrar;
using UniversalStrategyCore.Bootstrap;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.GameMath;

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
        var factionManager = gameBootstrap.GameServices.GetRequiredService<FactionManager>();
        var armyManager = gameBootstrap.GameServices.GetRequiredService<ArmyManager>();
    
        Player player1 = new("Loretty", false);
        Player player2 = new("AI", true);
        playerHolder.RegisterPlayer(player1);
        playerHolder.RegisterPlayer(player2);

        factionManager.RegisterFaction(player1.Name, FactionName.England);
        factionManager.RegisterFaction(player2.Name, FactionName.France);

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
        var army1 = armyManager.CreateArmy(FactionName.England, UnitType.Infantry, 1000);
    }   
}