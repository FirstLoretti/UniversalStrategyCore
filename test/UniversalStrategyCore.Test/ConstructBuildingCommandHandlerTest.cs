using UniversalStrategyCore.StrategicConstructionSystem.Data;
using UniversalStrategyCore.StrategicConstructionSystem.Logic;
using UniversalStrategyCore.EconomicSystem;
using NSubstitute;
using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Test;

public class ConstructBuildingCommandHandlerTest
{
    [Fact]
    public void Handle_Success_WhenResourcesEnough()
    {
        var economicManagerMock = Substitute.For<IFactionEconomicManager>();
        var constructionManagerMock = Substitute.For<IProvinceConstructionManager>();
        var factionTableMock = Substitute.For<IFactionTable>();

        Dictionary<GameResourceType, int> factionResourses = new() { { GameResourceType.Gold, 1000 } };
        FactionTemplate faction = new("1", "1", factionResourses);
        ProvinceTemplate province = new("1", "1");
        Dictionary<GameResourceType, int> buildingCost = new() { { GameResourceType.Gold, 500 } };
        BuildingTemplate building = new("1", "1", 1, buildingCost);
        ConstructionOrder order = new(building);

        ConstructBuildingCommand command = new(faction.Id, province.Id, order);
        ConstructBuildingCommandHandler commandHandler = new(economicManagerMock, constructionManagerMock, factionTableMock);
        factionTableMock.GetFaction(command.FactionId).Returns(faction);

        var result = commandHandler.Handle(command);

        Assert.True(result.IsSuccess);
        Assert.True(result.Value != null);
        constructionManagerMock.Received(1).AddConstructionOrder(command.ProvinceId, order);
        economicManagerMock.Received(1).ApplyTransaction(Arg.Any<EconomicTransactionCommand>());
    }

    [Fact]
    public void Handle_Success_WhenResourcesNotEnough()
    {
        var economicManagerMock = Substitute.For<IFactionEconomicManager>();
        var constructionManagerMock = Substitute.For<IProvinceConstructionManager>();
        var factionTableMock = Substitute.For<IFactionTable>();

        Dictionary<GameResourceType, int> factionResourses = new() { { GameResourceType.Gold, 0 } };
        FactionTemplate faction = new("1", "1", factionResourses);
        ProvinceTemplate province = new("1", "1");
        Dictionary<GameResourceType, int> buildingCost = new() { { GameResourceType.Gold, 500 } };
        BuildingTemplate building = new("1", "1", 1, buildingCost);
        ConstructionOrder order = new(building);

        ConstructBuildingCommand command = new(faction.Id, province.Id, order);
        ConstructBuildingCommandHandler commandHandler = new(economicManagerMock, constructionManagerMock, factionTableMock);
        factionTableMock.GetFaction(command.FactionId).Returns(faction);

        var result = commandHandler.Handle(command);

        Assert.True(!result.IsSuccess);
        Assert.True(result.Value == null);
        constructionManagerMock.DidNotReceive().AddConstructionOrder(command.ProvinceId, order);
        economicManagerMock.DidNotReceive().ApplyTransaction(Arg.Any<EconomicTransactionCommand>());
    }
}