using core;

public class SlimeStateData:IStateData
{
    public readonly StateId Idle = new StateId("Idle");
    public readonly StateId Rush = new StateId("Rush");
    public readonly StateId Jump = new StateId("Jump");
    public readonly StateId Return = new StateId("Return");

    public readonly SlimeIdleState SlimeIdleS;
    public readonly SlimeJumpState SlimeJumpS;
    public readonly SlimeRushState SlimeRushS;
    public readonly SlimeReturnPositionState SlimeReturnS;

    public readonly TriggerId IdleTrigger = new TriggerId("IdleTrigger");
    public readonly TriggerId RushTrigger = new TriggerId("RushTrigger");
    public readonly TriggerId JumpTrigger = new TriggerId("JumpTrigger");
    public readonly TriggerId ReturnTrigger = new TriggerId("ReturnTrigger");

    public SlimeStateData(
        SlimeIdleState slimeIldeState,
        SlimeJumpState slimeJumpState,
        SlimeRushState slimeRushState,
        SlimeReturnPositionState slimeReturnPositionState)
    {
        SlimeIdleS = slimeIldeState;
        SlimeJumpS = slimeJumpState;
        SlimeRushS = slimeRushState;
        SlimeReturnS = slimeReturnPositionState;
    }
    public (StateId, IState)[] GetStates()
    {
        return new (StateId, IState)[]
        {
            (Idle,SlimeIdleS),
            (Rush,SlimeRushS),
            (Jump,SlimeJumpS),
            (Return,SlimeReturnS)
        };
    }
    public (StateId, TriggerId, StateId)[] GetTransitions()
    {
        return new (StateId, TriggerId, StateId)[]
        {
            (Idle,RushTrigger,Rush),
            (Idle,JumpTrigger,Jump),
            (Jump,ReturnTrigger,Return),
            (Rush,IdleTrigger,Idle),
            (Jump,IdleTrigger,Idle),
            (Return,IdleTrigger,Idle)
        };
    }
}