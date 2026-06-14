using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.Province.BuildingSystem;

namespace UniversalStrategyCore.Province.Commands;

public record StartConstruction(ProvinceTemplate Province, ConstructionOrder ProvinceConstructionOrder)
{
    public void Execute(IServiceProvider serviceProvider)
    {
        var provinceConstructionManager = serviceProvider.GetRequiredService<ProvinceConstructionManager>();
        provinceConstructionManager.AddConstructionOrder(Province, ProvinceConstructionOrder);
    }
}

