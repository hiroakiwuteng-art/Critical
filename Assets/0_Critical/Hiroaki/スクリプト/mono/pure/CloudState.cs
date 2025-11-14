using core;
using UnityEngine;

public class CloudState:IState<BossStateData>
{
    public void Enter()
    {

    }
    public TriggerId? Tick(BossStateData data)
    {
        return null;
    }
    public void Exit()
    {

    }
}
