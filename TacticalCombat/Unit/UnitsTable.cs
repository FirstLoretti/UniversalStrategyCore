using System.Diagnostics;

namespace UniversalStrategyCore.TacticalCombat.Unit;

public class UnitsTable : IUnitsTable
{
    private readonly Dictionary<string, UnitTemplate> _idToUnit = [];

    public UnitsTable()
    {
        Initialize();
    }

    public UnitTemplate GetUnitTemplate(string id)
    {
        if (_idToUnit.TryGetValue(id, out var unitTemplate))
        {
            return unitTemplate;
        }
        Debug.Assert(false, $"Юнита под id: {id} нет в словаре");
        return UnitTemplate.Missing;
    }

    private void Initialize()
    {
        AddUnit(new UnitTemplate("swordman_1", "Мечник", UnitType.Swordman));
        AddUnit(new UnitTemplate("spearman_1", "Копейщик", UnitType.Spearman));
    }

    private void AddUnit(UnitTemplate unitTemplate)
    {
        var id = unitTemplate.Id.ToLowerInvariant();
        if (!_idToUnit.TryAdd(id, unitTemplate))
        {
            Debug.Assert(false, $"Юнит c id: {id} уже есть в таблице");
        }
    }
}