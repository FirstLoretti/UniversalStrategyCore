using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.ProvinceSystem.BuildingSystem;

public class ProvinceBuildingsRegistry: IProvinceBuildingsRegistry
{
    private readonly Dictionary <Shared.Province, List<Building>> _provinceToBuildings = [];

    public void AddBuildings(Shared.Province provinceTemplate, IEnumerable<Building> buildingTemplates)
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

    public void AddBuilding(Shared.Province provinceTemplate, Building buildingTemplate)
    {
        AddBuildings(provinceTemplate, [buildingTemplate]);
    }

    public IReadOnlyList<Building>? GetBuildings(Shared.Province provinceTemplate)
    {
        if(_provinceToBuildings.TryGetValue(provinceTemplate, out var buildingTemplates))
        {
            return buildingTemplates;
        }
        Console.WriteLine($"[ProvinceBuildings] Провинция: {provinceTemplate} не добавлена в _provinceToBuildings");
        return null;
    }
}