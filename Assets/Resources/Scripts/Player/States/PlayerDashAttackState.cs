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
        playerContext.Anim.SetTrigger("Dash");
        playerContext.DashTrail.GetComponent<TrailRenderer>().enabled = true;
        playerContext.RB.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
    }
    public override void UpdateState()
    {
        if (playerContext.RB.linearVelocity.x == 0f)
        {
            playerContext.DashFinished = true;
        }
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        Debug.Log("ending dash attack");
        playerContext.DashTrail.GetComponent<TrailRenderer>().enabled = false;
        playerContext.Anim.ResetTrigger("Dash");
    }

    public override void CheckSwitchStates()
    {
        if (playerContext.DashFinished)
        {
            SwitchState(new PlayerIdleState(playerContext));
        }
    }
}
