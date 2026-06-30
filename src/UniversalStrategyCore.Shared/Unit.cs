namespace UniversalStrategyCore.Shared;

public record class Unit(
    UnitId Id,
    string DisplayName,
    UnitType UnitType,
    float Speed,
    int Damage,
    int Health,
    int ExpKillReward,
    Dictionary<GameResourceType, int> Upkeep
);