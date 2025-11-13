using core;
using UnityEngine;

public class EnemyManager:MonoBehaviour
{
    private StateMachine<SlimeStateData> slimeSM;
    [SerializeField]private Animator SlimeAnimator;
    [SerializeField] private Transform SlimeTf;
    [SerializeField] private Transform PlayerTf;

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
            new IdleState(SlimeAnimator),
            new RushState(SlimeAnimator,SlimeTf,PlayerTf),
            new JumpState(SlimeAnimator,SlimeTf,PlayerTf),
            new ReturnState(SlimeAnimator,SlimeTf));
        return new StateMachine<SlimeStateData>(data);
    }
}
