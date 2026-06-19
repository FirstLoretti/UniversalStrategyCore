using UniversalStrategyCore.FactionEconomicSystem;
using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.PlayerRegistrar;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Turn;
using UniversalStrategyCore.Province.BuildingSystem;
using UniversalStrategyCore.Province;
using UniversalStrategyCore.TacticalCombat.Unit;
using UniversalStrategyCore.TacticalCombat.Mediators;
using UniversalStrategyCore.TacticalCombat.Squad;
using UniversalStrategyCore.Mediators.FactionProvince;
using UniversalStrategyCore.ConstructionSystem.Logic;

namespace UniversalStrategyCore.GameBootstrap;

public class GameBootstrap
{
    public ServiceProvider GameServices { get; init; }

    private readonly ServiceCollection _serviceCollection = new();

    public GameBootstrap()
    {
        RegisterPlayerSystem();
        RegisterArmySystem();
        RegisterTurnSystem();
        RegisterProvinceSystem();
        RegisterFactionSystem();
        RegisterTacticalBattleSystem();
        RegisterMediators();
        RegisterGameSession();

        GameServices = _serviceCollection.BuildServiceProvider();
        StartEventSystems();
    }

    private void StartEventSystems()
    {
        GameServices.GetRequiredService<ProvinceConstructionTurnEndMediator>();
    }

    private void RegisterArmySystem()
    {
        _serviceCollection.AddSingleton<ArmyManager>();
    }

    private void RegisterPlayerSystem()
    {
        _serviceCollection.AddSingleton<PlayerManager>();
    }

    private void RegisterTurnSystem()
    {
        _serviceCollection.AddSingleton<TurnManager>();
    }

    private void RegisterGameSession()
    {
        _serviceCollection.AddSingleton<GameSession>();
    }

    private void RegisterFactionSystem()
    {
        _serviceCollection.AddSingleton<IFactionTable, FactionsTable>();
        _serviceCollection.AddSingleton<FactionPlayerRegistrar>();
        _serviceCollection.AddSingleton<FactionEconomicManager>();
    }

    private void RegisterProvinceSystem()
    {
        _serviceCollection.AddSingleton<IProvinceTable,ProvinceTable>();
        _serviceCollection.AddSingleton<IProvinceConstructionManager, ProvinceConstructionManager>();
        _serviceCollection.AddSingleton<ProvinceManager>();
        _serviceCollection.AddSingleton<ProvinceBuildingsBalanceTable>();
        _serviceCollection.AddSingleton<ProvinceBuildingsRegistry>();
    }

    private void RegisterTacticalBattleSystem()
    {
        _serviceCollection.AddSingleton<IUnitsTable, UnitsTable>();
        _serviceCollection.AddSingleton<ISquadsTable, SquadsTable>();
    }

    private void RegisterMediators()
    {
        _serviceCollection.AddSingleton<ProvinceConstructionTurnEndMediator>();
        _serviceCollection.AddSingleton<IFactionProvincesTable, FactionProvincesTable>();
        _serviceCollection.AddSingleton<SquadFactory>();
        _serviceCollection.AddSingleton<FactionVisionManager>();
        _serviceCollection.AddSingleton<FactionVisionTable>();
        _serviceCollection.AddSingleton<StrategicalConstructionManager>();
    }
}