using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.Factions;

public class FactionTable : IFactionTable
{
    private readonly Dictionary<FactionId, FactionTemplate> _idToFaction = [];

    public FactionTable()
    {
        CreateFactions();
    }

    public FactionTemplate GetFaction(FactionId id)
    {
        if (_idToFaction.TryGetValue(id, out var faction))
        {
            return faction;
        }
        throw new ArgumentException($"[FactionTable] Фракция: {id} не добавлена в таблицу! Добавить в CreateFaction()");
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
        AddFaction(new FactionTemplate(Id: new FactionId("england"), DisplayName: "England", englandResources));
        AddFaction(new FactionTemplate(Id: new FactionId("france"), DisplayName:"France", franceResources));
    }

    private void AddFaction(FactionTemplate faction)
    {
        _idToFaction.Add(faction.Id, faction);
    }
}