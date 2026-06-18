namespace UniversalStrategyCore.Faction;

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
        AddFaction(new FactionTemplate(FactionName.England, Gold: 1000, Wood: 500));
        AddFaction(new FactionTemplate(FactionName.France, Gold: 2000, Wood: 250));
    }

    private void AddFaction(FactionTemplate factionTemplate)
    {
        _factionNameToFaction.Add(factionTemplate.Name, factionTemplate);
    }
}