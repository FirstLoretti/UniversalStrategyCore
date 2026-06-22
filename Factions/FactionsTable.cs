using UniversalStrategyCore.EconomicSystem;

namespace UniversalStrategyCore.Factions;

public class FactionsTable : IFactionTable
{
    private readonly Dictionary<FactionName, FactionTemplate> _factionNameToFaction = [];

    public FactionsTable()
    {
        Initialization();
    }

    public FactionTemplate GetFaction(FactionName factionName)
    {
        if (_factionNameToFaction.TryGetValue(factionName, out var faction))
        {
            return faction;
        }
        throw new ArgumentException($"[FactionTable] Фракция {factionName} не добавлена в таблицу! Добавить в CreateFaction()");
    }

    private void Initialization()
    {
        CreateFactions();
    }

    private void CreateFactions()
    {
        Dictionary<GameResourceType, int> englandResources = new()
        {
            {GameResourceType.Gold, 1000},
            {GameResourceType.Wood, 500}
        };
        Dictionary<GameResourceType, int> franceResources = new()
        {
            {GameResourceType.Gold, 2000},
            {GameResourceType.Wood, 250}
        };
        AddFaction(new FactionTemplate(FactionName.England, englandResources));
        AddFaction(new FactionTemplate(FactionName.France, franceResources));
    }

    private void AddFaction(FactionTemplate factionTemplate)
    {
        _factionNameToFaction.Add(factionTemplate.Name, factionTemplate);
    }
}