using UnityEngine;

public class PlayerDashSetUpState : State
{
    private PlayerStateMachine playerContext;
    public PlayerDashSetUpState(PlayerStateMachine currentContext) : base(currentContext)
    {
        playerContext = currentContext;
    }
    public override void EnterState()
    {
        Debug.Log("entering dash set up");
        playerContext.DashArrow.SetActive(true);
        playerContext.SetTimeScale(0.5f);
        playerContext.AppliedMovementX = 0f;
        playerContext.AppliedMovementY = 0f;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        Debug.Log("exiting dash set up");
        playerContext.SetTimeScale(1f);
    }

    public override void CheckSwitchStates()
    {
        if (!playerContext.IsDashPressed)
        {
            SwitchState(new PlayerDashAttackState(playerContext));
        }
    }
}
