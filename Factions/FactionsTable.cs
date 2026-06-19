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
        Dictionary<ResourceType, int> englandResources = new()
        {
            {ResourceType.Gold, 1000},
            {ResourceType.Wood, 500}
        };
        Dictionary<ResourceType, int> franceResources = new()
        {
            {ResourceType.Gold, 2000},
            {ResourceType.Wood, 250}
        };
        AddFaction(new FactionTemplate(FactionName.England, englandResources));
        AddFaction(new FactionTemplate(FactionName.France, franceResources));
    }

    private void AddFaction(FactionTemplate factionTemplate)
    {
        _factionNameToFaction.Add(factionTemplate.Name, factionTemplate);
    }
}