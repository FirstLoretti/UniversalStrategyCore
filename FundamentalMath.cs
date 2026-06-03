namespace InsideTheWar.GameMath;

public static class FundamentalMath
{
    public const float Zero = 0.0f;
    private static readonly Random _random = new();

    public static int GetRandomNumberInRange(int a, int b)
    {
        return _random.Next(a, b);
    }
}