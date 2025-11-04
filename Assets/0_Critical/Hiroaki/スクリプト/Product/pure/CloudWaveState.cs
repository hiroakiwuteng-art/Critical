using core;
using UnityEngine;

public class CloudWaveState:IState
{
    public void Enter()
    {
        Debug.Log("cloud enter");
    }
    public void Tick()
    {
        Debug.Log("cloud tick");
    }
    public void Exit()
    {
        Debug.Log("cloud exit");
    }
}
