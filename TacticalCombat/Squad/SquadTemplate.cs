namespace UniversalStrategyCore.TacticalCombat.Squad;

public record SquadTemplate(string Id, string UnitTemplateId, int UnitsCount)
{
    public static readonly SquadTemplate Missing = new("missing", "missing", 0);
}