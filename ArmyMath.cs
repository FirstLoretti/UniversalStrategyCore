namespace InsideTheWar.GameMath;

public static class ArmyMath
{
    public static int CalculatePower(int unitsCount)
    {
        float randomBonus = FundamentalMath.GetRandomNumberInRange(1, 25);
        float power = unitsCount + unitsCount * randomBonus / 100;
        int roundedPower = (int)MathF.Round(power, MidpointRounding.AwayFromZero);
        return roundedPower;
    }
    public static int CalculatePower(int unitsCount, float unitTypeAdvantage)
    {
        float randomBonus = FundamentalMath.GetRandomNumberInRange(1, 25);
        float power = (unitsCount + unitsCount * randomBonus / 100) * unitTypeAdvantage;
        int roundedPower = (int)MathF.Round(power, MidpointRounding.AwayFromZero);
        return roundedPower;
    }

    public static int CalculateRandomCasualties(int unitsCount)
    {
        int randomCasualties = FundamentalMath.GetRandomNumberInRange(25, 75);
        int casualties = unitsCount * randomCasualties / 100;
        return casualties;
    }

    public static int CalculateRandomCasualties(int unitsCount, float casualtiesMultiplicator)
    {
        float randomCasualties = FundamentalMath.GetRandomNumberInRange(25, 50);
        float totalCasualties = Math.Clamp(randomCasualties + casualtiesMultiplicator, 1.0f, 75.0f);
        float casualties = unitsCount * totalCasualties / 100.0f;
        int roundedCasualties = (int)MathF.Round(casualties, MidpointRounding.AwayFromZero);
        return roundedCasualties;
    }
}