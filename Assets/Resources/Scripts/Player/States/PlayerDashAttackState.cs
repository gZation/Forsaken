using UnityEngine;

public class PlayerDashAttackState : State
{
    private PlayerStateMachine playerContext;
    public PlayerDashAttackState(PlayerStateMachine currentContext) : base(currentContext)
    {
        playerContext = currentContext;
    }
    public override void EnterState()
    {
        Debug.Log("beginning dash attack");
        Vector2 direction = playerContext.DashArrow.GetComponent<Player_Dash_Direction>().DashDirection;
        playerContext.DashArrow.SetActive(false);
        playerContext.Anim.Play("Dash");
        playerContext.DashTrail.GetComponent<TrailRenderer>().enabled = true;
        playerContext.RB.AddForce(direction * playerContext.DashForce, ForceMode2D.Impulse);
        // playerContext.AppliedMovementX = playerContext.RunSpeed * 50f;
    }
    public override void UpdateState()
    {
        //playerContext.AppliedMovementX *= 0.75f;
        if (Mathf.Abs(playerContext.RB.linearVelocity.x) <= 0.01f)
        {
            playerContext.DashFinished = true;
        }
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        Debug.Log("ending dash attack");
        playerContext.DashTrail.GetComponent<TrailRenderer>().enabled = false;
    }

    public override void CheckSwitchStates()
    {
        if (playerContext.DashFinished)
        {
            SwitchState(new PlayerIdleState(playerContext));
        }
    }
}
