using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.PlayerSystem;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Turn;
using UniversalStrategyCore.ProvinceSystem.BuildingSystem;
using UniversalStrategyCore.ProvinceSystem;
using UniversalStrategyCore.Mediators.FactionProvince;
using UniversalStrategyCore.StrategicConstructionSystem.Logic;
using UniversalStrategyCore.StrategicConstructionSystem.Data;
using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Factory;

namespace UniversalStrategyCore.GameBootstrap;

public class GameBootstrap
{
    public ServiceProvider GameServices { get; init; }

    private readonly ServiceCollection _serviceCollection = new();

    public GameBootstrap()
    {
        PlayerSystem();
        RegisterArmySystem();
        RegisterTurnSystem();
        RegisterProvinceSystem();
        RegisterFactionSystem();
        RegisterTacticalCombatSystem();
        RegisterEconomicSystem();
        RegisterConstructionSystem();
        RegisterMediators();
        RegisterGameSession();
        RegisterShared();
        RegisterUnnamed();

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

    private void PlayerSystem()
    {
        _serviceCollection.AddSingleton<IPlayerRegistry, PlayerRegistry>();
        _serviceCollection.AddSingleton<ICommandHandler<CreatePlayerCommand>, CreatePlayerCommandHandler>();
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
        _serviceCollection.AddSingleton<IFactionTable, FactionTable>();
        _serviceCollection.AddSingleton<FactionPlayerRegistrar>();
    }

    private void RegisterProvinceSystem()
    {
        _serviceCollection.AddSingleton<IProvinceTable, ProvinceTable>();
        _serviceCollection.AddSingleton<ProvinceManager>();
        _serviceCollection.AddSingleton<ProvinceBuildingsBalanceTable>();
        _serviceCollection.AddSingleton<ProvinceBuildingsRegistry>();
    }

    private void RegisterConstructionSystem()
    {
        _serviceCollection.AddSingleton<IProvinceConstructionManager, ProvinceConstructionManager>();
        _serviceCollection.AddSingleton<ICommandHandler<ConstructBuildingCommand>, ConstructBuildingCommandHandler>();
    }

    private void RegisterEconomicSystem()
    {
        _serviceCollection.AddSingleton<IFactionEconomicManager, FactionEconomicManager>();
    }

    private void RegisterTacticalCombatSystem()
    {
        _serviceCollection.AddSingleton<TacticalSquadFactory>();
    }

    private void RegisterMediators()
    {
        _serviceCollection.AddSingleton<ProvinceConstructionTurnEndMediator>();
        _serviceCollection.AddSingleton<IFactionProvincesTable, FactionProvincesTable>();
        _serviceCollection.AddSingleton<FactionVisionManager>();
        _serviceCollection.AddSingleton<FactionVisionTable>();
    }

    private void RegisterShared()
    {
        _serviceCollection.AddSingleton<IUnitRepository, UnitRepository>();
        _serviceCollection.AddSingleton<ISquadRepository, SquadRepository>();
        _serviceCollection.AddSingleton<ICultureNamesRepository, CultureNamesRepository>();
    }

    private void RegisterUnnamed()
    {
        _serviceCollection.AddSingleton<IExperienceSquadTable, ExperienceSquadTable>();
    }
}