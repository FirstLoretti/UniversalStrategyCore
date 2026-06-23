namespace UniversalStrategyCore.GameMath;

public class RandomProvider : IRandomProvider
{
    private readonly Random _random = new();

    public int GetRandomNumberInRange(int min, int max) => _random.Next(min, max);
}