using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Factionn;
using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Units;
using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Test;

public class ArmyTest
{
    private ArmyManager _armyManager = new();

    [Theory]
    [InlineData(-5f, 1000)]
    [InlineData(0f, 1000)]
    [InlineData(10f, 900)]
    [InlineData(100f, 0)]
    [InlineData(1000f, 0)]

    public void TakeCasualties(float percent, int unitsRemaining)
    {
        var army = _armyManager.CreateArmy("1", UnitType.Cavalry, 1000);
        army.TakeCasualties(percent);
        Assert.Equal(unitsRemaining, army.UnitsCount);
    }

    [Theory]
    [InlineData(-5f, 100f)]
    [InlineData(0f, 100f)]
    [InlineData(10f, 90f)]
    [InlineData(100f, 0f)]
    [InlineData(1000f, 0f)]

    public void MoralePenalty(float percent, float moraleRemaining)
    {
        var army = _armyManager.CreateArmy("1", UnitType.Cavalry, 1000);
        army.MoralePenalty(percent);
        Assert.Equal(moraleRemaining, army.Stats.Morale);
    }
}