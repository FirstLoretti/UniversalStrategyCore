using UniversalStrategyCore.Factions;

namespace UniversalStrategyCore.Faction.AI;

public class AIFaction(FactionTemplate faction, DefaultState defaultState, AggressiveState aggressiveState)
{
    public FactionTemplate Faction { get; } = faction;
    public DefaultState DefaultState { get; } = defaultState;
    public AggressiveState AggressiveState { get; } = aggressiveState;

    private IState _state = defaultState;

    public void OnTurnEnd()
    {
        UpdateState();
        _state.Strategy.Apply(this);
    }

    public void ChangeState(IState state) => _state = state;

    private void UpdateState() => _state.Update(this);
}