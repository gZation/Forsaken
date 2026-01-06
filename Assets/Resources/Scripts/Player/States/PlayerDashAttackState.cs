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
        Vector2 direction = playerContext.DashArrow.GetComponent<Player_Dash_Direction>().DashDirection;
        playerContext.DashArrow.SetActive(false);
        playerContext.Anim.Play("Dash");
        playerContext.DashTrail.GetComponent<DashTrail>().IsDrawingTrail = true;
        playerContext.DashTrail.GetComponent<DashTrail>().Direction = new Vector3(Mathf.Sign(direction.x), 0, 0);
        playerContext.RB.AddForce(direction * playerContext.DashForce, ForceMode2D.Impulse);
        Physics2D.IgnoreLayerCollision(6, 7, true);
    }
    public override void UpdateState()
    {
        if (Mathf.Abs(playerContext.RB.linearVelocity.x) <= 0.01f)
        {
            playerContext.DashFinished = true;
        }
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.DashTrail.GetComponent<DashTrail>().IsDrawingTrail = false;
        playerContext.DashTrail.GetComponent<DashTrail>().Clear();
        Physics2D.IgnoreLayerCollision(6, 7, false);
        playerContext.CurrentDashMeter = 0;
        
    }

    public override void CheckSwitchStates()
    {
        if (playerContext.DashFinished)
        {
            SwitchState(new PlayerIdleState(playerContext));
        }
    }
}
