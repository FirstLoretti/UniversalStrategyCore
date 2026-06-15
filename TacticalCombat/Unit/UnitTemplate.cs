namespace UniversalStrategyCore.TacticalCombat.Unit;

public record class UnitTemplate(string Id, string DisplayName, UnitType UnitType)
{
    public static readonly UnitTemplate Missing = new(Id: "missing", DisplayName: "Пропавший", UnitType: UnitType.Swordman);
}