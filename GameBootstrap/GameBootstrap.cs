using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Managers;
using UniversalStrategyCore.Mediators;
using UniversalStrategyCore.PlayerRegistrar;
using UniversalStrategyCore.Provinces;
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.Armies;

namespace UniversalStrategyCore.Bootstrap;

public class GameBootstrap
{
    public ServiceProvider GameServices { get; init; }

    public GameBootstrap()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<TurnManager>();
        serviceCollection.AddSingleton<ProvinceManager>();
        serviceCollection.AddSingleton<PlayerHolder>();
        serviceCollection.AddSingleton<FactionManager>();
        serviceCollection.AddSingleton<ArmyManager>();
        serviceCollection.AddSingleton<ProvinceTurnEndMediator>();
        InitializeFactionProvinces(serviceCollection);

        GameServices = serviceCollection.BuildServiceProvider();
        GameServices.GetRequiredService<ProvinceTurnEndMediator>();
    }

    private void InitializeFactionProvinces(ServiceCollection serviceCollection)
    {
        List<FactionStartingProvinces> factionStartingProvinces =
        [
            new FactionStartingProvinces(FactionName.England, [ProvinceName.London]),
            new FactionStartingProvinces(FactionName.France, [ProvinceName.Paris])
        ];
        serviceCollection.AddSingleton(new FactionProvincesRegistry(factionStartingProvinces));
    }
}