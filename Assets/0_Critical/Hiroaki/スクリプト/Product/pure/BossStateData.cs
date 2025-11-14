using core;
using UnityEngine;

public class BossStateData:IStateData<BossStateData>
{
    private readonly SlimeState slimeState;
    private readonly StateId slimeId = new("slime");
    private readonly TriggerId SlimeTrigger = new("slimeTrigger");

    public BossStateData(SlimeState slimeState)
    {
        this.slimeState = slimeState;
    }
    public (StateId,IState<BossStateData>)[] GetStates()
    {
        return new (StateId, IState<BossStateData>)[]
        {
            (slimeId,slimeState)
        };
    }
    public (StateId, TriggerId, StateId)[] GetTransitions()
    {
        return new (StateId, TriggerId, StateId)[]
        {

        };
    }
    public StateId GetInitStateId()
    {
        return slimeId;
    }
}
