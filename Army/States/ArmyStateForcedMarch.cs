using System.Numerics;

namespace UniversalStrategyCore.Armies.States;

public class ArmyStateForcedMarch : IArmyState
{
    public string Name { get; init; } = "ForcedMarch";
    public float MoralePenalty { get; private set; } = 0.1f;
    public float AttritionCasualties { get; private set; } = 0.05f;
    public float bonusMovePoints = 1.5f;

    public void MoveTo(Army army, Vector2 destination)
    {
        Console.WriteLine(
            $"Армия на форсированном марше к :{destination}. " +
            $"Бонусн очков перемещения: {bonusMovePoints}. " +
            $"Очки перемещения: {army.Stats.MovePoints * bonusMovePoints}"
        );
    }

    public void ApplyTurnEndPenalties(Army army)
    {
        army.MoralePenalty(MoralePenalty);
        int attritionCasualties = (int)MathF.Round(army.UnitsCount * AttritionCasualties, MidpointRounding.AwayFromZero);
        army.TakeCasualties(attritionCasualties);
        Console.WriteLine(
            $"Процент штрафа при форсированном марше к боевому духу: {MoralePenalty * 100.0f}, текущий боевой дух: {army.Stats.Morale}. " +
            $"Процент небоевых потерь: {AttritionCasualties * 100.0f}, составил: {attritionCasualties}, текущее количество юнитов: {army.UnitsCount}."
        );

    }
}