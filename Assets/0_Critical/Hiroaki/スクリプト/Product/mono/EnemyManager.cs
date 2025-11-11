using core;
using UnityEngine;

public class EnemyManager:MonoBehaviour
{
    private StateMachine<SlimeStateData> slimeSM;
    [SerializeField]private Animator SlimeAnimator;
    [SerializeField] private Transform SlimeTf;

    public void Start()
    {
        slimeSM = createSlimeSM();
        slimeSM.Enter();
    }
    public void Update()
    {
        slimeSM.Tick();
    }
    public void OnDisable()
    {
        slimeSM.Exit();
    }
    private StateMachine<SlimeStateData> createSlimeSM()
    {
        SlimeStateData data = new SlimeStateData(
            new IdleState(),
            new RushState(SlimeAnimator,SlimeTf),
            new JumpState(SlimeAnimator),
            new ReturnState());
        return new StateMachine<SlimeStateData>(data);
    }
}
