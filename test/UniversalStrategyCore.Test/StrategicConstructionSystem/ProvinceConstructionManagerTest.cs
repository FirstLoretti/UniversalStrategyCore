using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;
using UniversalStrategyCore.StrategicConstructionSystem.Logic;

namespace UniversalStrategyCore.Test.StrategicConstructionSystem;

public class ProvinceConstructionManagerTest
{
    [Fact]
    public void OnTurnEnd_ShouldFinishConstructionAndTriggerEvent_WhenOneTurnRemainig()
    {
        ProvinceConstructionManager manager = new();
        Province province = new("1", "1");
        ConstructionOrder order = new(new Building("1", "1", 1, []));
        bool isTriggered = false;

        manager.AddConstructionOrder(province.Id, order);
        manager.BuildingConstructed += () => isTriggered = true;

        manager.OnTurnEnd(province.Id);

        Assert.True(order.IsFinished);
        Assert.True(isTriggered);
    }

    [Fact]
    public void OnTurnEnd_ShouldNotFinishConstructionAndNotTriggerEvent_WhenMultipleTurnsRemaining()
    {
        ProvinceConstructionManager manager = new();
        Province province = new("1", "1");
        ConstructionOrder order = new(new Building("1", "1", 2, []));
        bool isTriggered = false;

        manager.AddConstructionOrder(province.Id, order);
        manager.BuildingConstructed += () => isTriggered = true;

        manager.OnTurnEnd(province.Id);

        Assert.False(isTriggered);
        Assert.False(order.IsFinished);
    }

    [Fact]
    public void OnTurnEnd_ShouldDoNothingAndNoThrow_WhenProvinceHasNoOrders()
    {
        ProvinceConstructionManager manager = new();
        Province province = new("1", "1");
        bool isTriggered = false;

        manager.BuildingConstructed += () => isTriggered = true;

        var exсeption = Record.Exception(() => manager.OnTurnEnd(province.Id));

        Assert.Null(exсeption);
        Assert.True(!isTriggered);
    }
}