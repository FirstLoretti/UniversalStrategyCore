
using UniversalStrategyCore.Map;
using UniversalStrategyCore.StrategyBattle;
using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Units;
using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.Map.WeatherLogic;
using UniversalStrategyCore.AI.Faction;
using UniversalStrategyCore.PlayerRegistrar;
using UniversalStrategyCore.GameBootstrap;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.GameMath;
using UniversalStrategyCore.Turn;
using UniversalStrategyCore.Province.BuildingSystem;
using UniversalStrategyCore.Province.Commands;
using UniversalStrategyCore.Province;
using UniversalStrategyCore.TacticalCombat.Unit;
using UniversalStrategyCore.TacticalCombat.Squad;
using UniversalStrategyCore.TacticalCombat.Mediators;

class Program
{
    public static void Main(string[] args)
    {
        GameBootstrap gameBootstrap = new();
        var gameSession = gameBootstrap.GameServices.GetRequiredService<GameSession>();
        gameSession.Start();
    }
}

class GameSession(
    ProvinceManager provinceManager, TurnManager turnManager, PlayerManager playerManager, FactionManager factionManager,
    ArmyManager armyManager, FactionsTable factionsTable, FactionProvincesTable factionProvincesTable,
    ProvinceConstructionManager provinceConstructionManager, ProvinceBuildings provinceBuildings,
    ProvinceBuildingsTable provinceBuildingsTable, IUnitsTable unitsTable, ISquadsTable squadsTable,
    SquadFactory squadFactory
)
{
    public void Start()
    {
        Player player1 = new("Loretty", false);
        Player player2 = new("AI", true);
        playerManager.RegisterPlayer(player1);
        playerManager.RegisterPlayer(player2);

        var england = factionsTable.GetFaction(FactionName.England);
        var france = factionsTable.GetFaction(FactionName.France);
        factionManager.RegisterFactionByPlayer(player1.Name, england);
        factionManager.RegisterFactionByPlayer(player2.Name, france);
        var englandProvinces = factionProvincesTable.GetProvinces(england);
        var franceProvinces = factionProvincesTable.GetProvinces(france);
        provinceManager.AddPlayerProvinces(player1.Name, englandProvinces);
        provinceManager.AddPlayerProvinces(player2.Name, franceProvinces);

        // Строительство
        // var farm = provinceBuildingsTable.GetBuilding("farm_1");
        // var barrack = provinceBuildingsTable.GetBuilding("barrack_1");
        // var london = provinceManager.GetPlayerProvince(player1.Name, ProvinceName.London);
        // var paris = provinceManager.GetPlayerProvince(player2.Name, ProvinceName.Paris);
        // provinceConstructionManager.AddConstructionOrder(london, new ConstructionOrder(farm));
        // provinceConstructionManager.AddConstructionOrder(paris, new ConstructionOrder(barrack));

        // turnManager.TurnEnd(player1.Name);
        // turnManager.TurnEnd(player2.Name);
        // turnManager.TurnEnd(player1.Name);
        // turnManager.TurnEnd(player2.Name);

        // Тактическая битва
        var squad1 = squadFactory.CreateSquad("swordmen_1");
        var squad2 = squadFactory.CreateSquad("spearmen_1");
        squad1.UnitsCount();
        squad2.UnitsCount();

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
        //AIFaction aIFaction = new(FactionName.France);
        //var army1 = armyManager.CreateArmy(FactionName.England, UnitType.Infantry, 1000);
    }
}