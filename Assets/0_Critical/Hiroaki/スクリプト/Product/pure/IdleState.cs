using core;
using UnityEngine;

public class IdleState:IState<SlimeStateData>
{
    public void Enter()
    {
        
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        return data.RushTrigger;
    }
    public void Exit()
    {

    }
}
