using NSubstitute;
using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Factory;

namespace UniversalStrategyCore.Test.TacticalCombat;

public class TacticalCombatTest
{
    [Fact]
    public void Attack_ShouldReduceEnemyUnits_TriggerCounterattack_AndGiveExpToBoth()
    {
        var squadRepository = Substitute.For<ISquadRepository>();
        var unitRepository = Substitute.For<IUnitRepository>();
        var experienceTable = Substitute.For<IExperienceSquadTable>();
        TacticalSquadFactory squadFactory = new(squadRepository, unitRepository, experienceTable);
        Unit unit = new(
                Id: "swordman",
                DisplayName: "Мечник",
                UnitType.Swordman,
                Speed: 1f,
                Damage: 5,
                Health: 25,
                ExpKillReward: 10,
                Upkeep: new() { { GameResourceType.Gold, 1 } }
            );
        Squad squad = new(
                Id: "swordmen",
                DisplayName: "Мечники",
                UnitId: "swordman",
                UnitsCount: 100,
                MaxUnits: 100
            );
        unitRepository.GetUnit("swordman").Returns(unit);
        squadRepository.GetSquad("swordmen").Returns(squad);
        experienceTable.GetLevel(160).Returns(1);
        experienceTable.GetLevel(200).Returns(2);

        var englandSquad = squadFactory.CreateSquad("swordmen", 1, "england").Value!;
        var franceSquad = squadFactory.CreateSquad("swordmen", 2, "france").Value!;

        englandSquad.BattleComponent.Attack(franceSquad);

        Assert.Equal(80, franceSquad.UnitsCount);
        Assert.Equal(84, englandSquad.UnitsCount); // Получил контратаку от 80 юнитов
        Assert.Equal(200, englandSquad.Experience);
        Assert.Equal(160, franceSquad.Experience);
        Assert.Equal(2, englandSquad.Level);
        Assert.Equal(1, franceSquad.Level);
    }
}