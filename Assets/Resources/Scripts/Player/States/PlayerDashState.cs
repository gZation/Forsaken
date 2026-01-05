using UnityEngine;

public class PlayerDashState : State
{
    private PlayerStateMachine playerContext;
    public PlayerDashState(PlayerStateMachine currentContext) : base(currentContext)
    {
        playerContext = currentContext;
        isBaseState = true;
        InitializeSubStates();
    }
    public override void InitializeSubStates()
    {
        if (playerContext.IsDashPressed)
        {
            SetSubState(new PlayerDashSetUpState(playerContext));
        }
    }
    public override void EnterState()
    {
        Debug.Log("dash parent state enter");
        playerContext.DashFinished = false;
        playerContext.CanMove = false;
        // playerContext.AppliedMovementX = 0f;
        // playerContext.AppliedMovementY = 0f;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        Debug.Log("dash parent state exit");
        playerContext.CanMove = true;
    }

    public override void CheckSwitchStates()
    {
        if (!playerContext.IsDashPressed && playerContext.DashFinished)
        {
            SwitchState(new PlayerIdleState(playerContext));
        }
    }
}
