namespace UniversalStrategyCore.Shared;

public class ExperienceSquadTable : IExperienceSquadTable
{
    private readonly Dictionary<int, int> _levelToExp = new()
    {
        { 0, 0 },
        { 1, 200 },
        { 2, 400 }
    };

    public int GetLevel(int experiece)
    {
        int currentLevel = 1;
        foreach (var (level, threshold) in _levelToExp)
        {
            if(experiece > threshold) currentLevel = level;
            else break;
        }
        return currentLevel;
    }
}