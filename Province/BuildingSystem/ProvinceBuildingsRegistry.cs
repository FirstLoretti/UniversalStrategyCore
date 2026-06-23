using UniversalStrategyCore.StrategicConstructionSystem;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.Province.BuildingSystem;

public class ProvinceBuildingsRegistry: IProvinceBuildingsRegistry
{
    private readonly Dictionary <ProvinceTemplate, List<BuildingTemplate>> _provinceToBuildings = [];

    public void AddBuildings(ProvinceTemplate provinceTemplate, IEnumerable<BuildingTemplate> buildingTemplates)
    {
        if(!_provinceToBuildings.TryGetValue(provinceTemplate, out var buildings))
        {
            buildings = [];
            _provinceToBuildings.Add(provinceTemplate, buildings);
        }
        buildings.AddRange(buildingTemplates);
        var buildingsName = string.Join(",", buildings);
        Console.WriteLine($"[ProvinceBuildings] B провинции: {provinceTemplate.Id} построены здания: {buildingsName}.");
    }

    public void AddBuilding(ProvinceTemplate provinceTemplate, BuildingTemplate buildingTemplate)
    {
        AddBuildings(provinceTemplate, [buildingTemplate]);
    }

    public IReadOnlyList<BuildingTemplate>? GetBuildings(ProvinceTemplate provinceTemplate)
    {
        if(_provinceToBuildings.TryGetValue(provinceTemplate, out var buildingTemplates))
        {
            return buildingTemplates;
        }
        Console.WriteLine($"[ProvinceBuildings] Провинция: {provinceTemplate} не добавлена в _provinceToBuildings");
        return null;
    }
}