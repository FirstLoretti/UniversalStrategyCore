namespace UniversalStrategyCore.GameMath;

public static class ArmyMath
{
    private static readonly RandomProvider _random = new();

    public static int CalculatePower(int unitsCount, float unitTypeAdvantage = 1f, IRandomProvider? randomProvider = null)
    {
        var random = randomProvider ?? _random;
        float randomBonus = random.GetRandomNumberInRange(1, 25);
        int power = (int)((unitsCount + unitsCount * randomBonus / 100) * unitTypeAdvantage);
        return power;
    }

    public static int CalculateRandomCasualties(int unitsCount, float casualtiesMultiplicator = 1f, IRandomProvider? randomProvider = null)
    {
        var random = randomProvider ?? _random;
        float randomPenalty = random.GetRandomNumberInRange(25, 50);
        float totalCasualties = Math.Clamp(randomPenalty + casualtiesMultiplicator, 1.0f, 75.0f);
        int casualties = (int)(unitsCount * totalCasualties / 100.0f);
        return casualties;
    }
}