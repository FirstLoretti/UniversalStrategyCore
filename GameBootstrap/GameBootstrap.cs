using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.PlayerRegistrar;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Turn;
using UniversalStrategyCore.Province.BuildingSystem;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.GameBootstrap;

public class GameBootstrap
{
    public ServiceProvider GameServices { get; init; }

    private ServiceCollection _serviceCollection = new();

    public GameBootstrap()
    {
        _serviceCollection.AddSingleton<TurnManager>();
        _serviceCollection.AddSingleton<PlayerManager>();
        _serviceCollection.AddSingleton<ArmyManager>();
        InitializeProvinceSystem();
        InitializeFactionSystem();
        InitializeMediators();

        GameServices = _serviceCollection.BuildServiceProvider();
        GameServices.GetRequiredService<ProvinceConstructionTurnEndMediator>();
        GameServices.GetRequiredService<FactionProvincesTable>();
    }

    private void InitializeFactionSystem()
    {
        _serviceCollection.AddSingleton<FactionsTable>();
        _serviceCollection.AddSingleton<FactionProvincesTable>();
        _serviceCollection.AddSingleton<FactionManager>();
    }

    private void InitializeProvinceSystem()
    {
        _serviceCollection.AddSingleton<ProvincesTable>();
        _serviceCollection.AddSingleton<ProvinceConstructionManager>();
        _serviceCollection.AddSingleton<ProvinceManager>();
        _serviceCollection.AddSingleton<ProvinceBuildingsTable>();
        _serviceCollection.AddSingleton<ProvinceBuildings>();
    }

    private void InitializeMediators()
    {
        _serviceCollection.AddSingleton<ProvinceConstructionTurnEndMediator>();
        _serviceCollection.AddSingleton<FactionProvincesTable>();
    }
}