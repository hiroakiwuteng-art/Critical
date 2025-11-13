using core;
using UnityEngine;

public class BossStateData:IStateData<BossStateData>
{
    public (StateId,IState<BossStateData>)[] GetStates()
    {
        return new (StateId, IState<BossStateData>)[]
        {

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
        return new StateId("");
    }
}
