namespace InsideTheWar.GameMath;

public static class FundamentalMath
{
    private static readonly Random _random = new();

    public static int GetRandomNumberInRange(int a, int b)
    {
        return _random.Next(a, b);
    }
}