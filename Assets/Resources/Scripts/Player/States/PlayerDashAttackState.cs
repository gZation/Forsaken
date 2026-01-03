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
        Vector2 direction = new Vector2(playerContext.Sprite.localScale.x, 0f);
        playerContext.RB.AddForce(direction * playerContext.RunSpeed * 20f, ForceMode2D.Impulse);
        // playerContext.AppliedMovementX = playerContext.RunSpeed * 50f;
    }
    public override void UpdateState()
    {
        //playerContext.AppliedMovementX *= 0.75f;
        if (playerContext.RB.linearVelocity.x <= 0.01f)
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
