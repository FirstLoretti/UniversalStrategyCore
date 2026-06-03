using InsideTheWar.Battle;

namespace InsideTheWar.Units;

public class UnitMatchupTable : IUnitMatchupTable
{
    private Dictionary<UnitType, Dictionary<UnitType, float>> _matchups = [];

    public UnitMatchupTable()
    {
        InitializeMatchups();
    }

    public float GetUnitTypeAdvantage(UnitType attacker, UnitType defender)
    {
        if (_matchups.TryGetValue(attacker, out var defenderDictionary))
        {
            var advantage = defenderDictionary[defender];
            return advantage;
        }
        float withoutAdvantage = 1.0f;
        return withoutAdvantage;
    }

    private void InitializeMatchups()
    {
        UnitMatchup[] unitMatchups =
        [
            new UnitMatchup(UnitType.Cavalry, UnitType.Spearmen, 0.75f),
            new UnitMatchup(UnitType.Cavalry, UnitType.Infantry, 1.25f),

            new UnitMatchup(UnitType.Spearmen, UnitType.Cavalry, 1.25f),
            new UnitMatchup(UnitType.Spearmen, UnitType.Infantry, 0.75f),

            new UnitMatchup(UnitType.Infantry, UnitType.Spearmen, 1.25f),
            new UnitMatchup(UnitType.Infantry, UnitType.Cavalry, 0.75f),
        ];

        foreach (var unitMatchup in unitMatchups)
        {
            if (!_matchups.ContainsKey(unitMatchup.Attacker))
            {
                var defender = new Dictionary<UnitType, float> { { unitMatchup.Defender, unitMatchup.Advantage } };
                _matchups.Add(unitMatchup.Attacker, defender);
            }
            else
            {
                _matchups[unitMatchup.Attacker].Add(unitMatchup.Defender, unitMatchup.Advantage);
            }
        }
    }
}