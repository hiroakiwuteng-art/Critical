using core;
using UnityEngine;

public class EnemyManager:MonoBehaviour
{
    private StateMachine<SlimeStateData> createSlimeSM()
    {
        SlimeStateData data = new SlimeStateData(
            new IdleState(),
            new RushState(),
            new JumpState(),
            new ReturnState());
        return new StateMachine<SlimeStateData>(data);
    }
}
