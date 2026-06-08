using InsideTheWar.Managers;
using InsideTheWar.Mediators;
using InsideTheWar.PlayerRegistrar;
using InsideTheWar.Provinces;
using Microsoft.Extensions.DependencyInjection;

namespace InsideTheWar.Bootstrap;

public class GameBootstrap
{
    public ServiceProvider GameServices { get; init; }

    public GameBootstrap()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<TurnManager>();
        serviceCollection.AddSingleton<ProvinceManager>();
        serviceCollection.AddSingleton<PlayerHolder>();
        serviceCollection.AddSingleton<ProvinceTurnEndMediator>();
        GameServices = serviceCollection.BuildServiceProvider();

        GameServices.GetRequiredService<ProvinceTurnEndMediator>();
    }
}