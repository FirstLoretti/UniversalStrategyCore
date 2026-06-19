
using UniversalStrategyCore.Map;
using UniversalStrategyCore.StrategyBattle;
using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Units;
using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.Map.WeatherLogic;
using UniversalStrategyCore.PlayerRegistrar;
using UniversalStrategyCore.GameBootstrap;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.GameMath;
using UniversalStrategyCore.Turn;
using UniversalStrategyCore.Province.BuildingSystem;
using UniversalStrategyCore.Province;
using UniversalStrategyCore.TacticalCombat.Unit;
using UniversalStrategyCore.TacticalCombat.Squad;
using UniversalStrategyCore.TacticalCombat.Mediators;
using UniversalStrategyCore.TacticalCombat.Squad.FSM;
using UniversalStrategyCore.TacticalCombat;
using System.Numerics;
using UniversalStrategyCore.Mediators.FactionProvince;
using UniversalStrategyCore.Faction.AI;
using UniversalStrategyCore;
using UniversalStrategyCore.ConstructionSystem;
using UniversalStrategyCore.Factions;
using UniversalStrategyCore.ConstructionSystem.Logic;
using UniversalStrategyCore.ConstructionSystem.Data;

#pragma warning disable CS9113

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
    ProvinceManager provinceManager, TurnManager turnManager, PlayerManager playerManager, FactionPlayerRegistrar factionManager,
    ArmyManager armyManager, IFactionTable factionTable, IFactionProvincesTable factionProvincesTable,
    IProvinceConstructionManager provinceConstructionManager, ProvinceBuildingsRegistry provinceBuildings,
    ProvinceBuildingsBalanceTable provinceBuildingsTable, IUnitsTable unitsTable, ISquadsTable squadsTable,
    SquadFactory squadFactory, FactionVisionManager factionVisionManager, StrategicalConstructionManager strategicalConstructionManager
)
{
    public void Start()
    {
        // Player player1 = new("Loretty", false);
        // Player player2 = new("AI", true);
        // playerManager.RegisterPlayer(player1);
        // playerManager.RegisterPlayer(player2);
        var player1 = playerManager.CreatePlayer("AI", true).Value;
        var player2 = playerManager.CreatePlayer("Loretty", false).Value;

        var england = factionTable.GetFaction(FactionName.England);
        var france = factionTable.GetFaction(FactionName.France);
        factionManager.RegisterFactionByPlayer(player1!.Name, england);
        factionManager.RegisterFactionByPlayer(player2!.Name, france);
        var englandProvinces = factionProvincesTable.GetProvinces(england);
        var franceProvinces = factionProvincesTable.GetProvinces(france);
        provinceManager.AddPlayerProvinces(player1.Name, englandProvinces);
        provinceManager.AddPlayerProvinces(player2.Name, franceProvinces);

        //Глобальный вижн
        // var isEnglandDiscover = new IsFactionDiscoveredCheck(factionVisionManager, england);
        // var isFranceDiscover = new IsFactionDiscoveredCheck(factionVisionManager, france);
        // isEnglandDiscover.IsPassed(france);
        // isFranceDiscover.IsPassed(france);

        //Faction AI
        // var aiFrance = new AIFaction(france, new DefaultState(), new AggressiveState());
        // var aiEngland = new AIFaction(england, new DefaultState(), new AggressiveState());
        // aiFrance.OnTurnEnd();
        // aiEngland.OnTurnEnd();

        //Строительство
        var farm = provinceBuildingsTable.GetBuilding("farm_1");
        var barrack = provinceBuildingsTable.GetBuilding("barrack_1");
        var london = provinceManager.GetPlayerProvince(player1.Name, ProvinceName.London);
        var paris = provinceManager.GetPlayerProvince(player2.Name, ProvinceName.Paris);
        ConstructBuildingCommand constructFarm = new(england, london, farm);
        ConstructBuildingCommand constructBarrack = new(france, paris, barrack);
        strategicalConstructionManager.ConstructBuilding(constructFarm);
        strategicalConstructionManager.ConstructBuilding(constructBarrack);

        turnManager.TurnEnd(player1.Name);
        turnManager.TurnEnd(player2.Name);
        turnManager.TurnEnd(player1.Name);
        turnManager.TurnEnd(player2.Name);

        //Тактическая битва
        // var squad1 = squadFactory.CreateSquad("swordmen_1");
        // var squad2 = squadFactory.CreateSquad("spearmen_1");
        // squad2.MovementComponent.ChangeState(new SquadStateIdle(squad2));
        // squad1.MovementComponent.MoveTo(new Vector2(10f, 5f));
        // Console.WriteLine("Запуск симуляции");
        // float fakeDeltaTime = 0.033f;
        // for (int i = 1; i <= 10; i++)
        // {
        //     squad1.MovementComponent.Update(fakeDeltaTime);
        //     Console.WriteLine($"Тик номер: {i}");
        // }

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