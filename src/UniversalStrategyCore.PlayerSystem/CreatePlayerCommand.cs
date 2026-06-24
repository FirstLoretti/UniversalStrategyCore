using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.PlayerSystem;

public record CreatePlayerCommand(string Name, bool IsAI) : IGameCommand;