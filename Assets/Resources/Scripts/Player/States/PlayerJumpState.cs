using UnityEngine;

public class PlayerJumpState : State
{
    private PlayerStateMachine playerContext;
    public PlayerJumpState(PlayerStateMachine currentContext) : base(currentContext)
    {
        playerContext = currentContext;
        isBaseState = true;
    }
    public override void EnterState()
    {
        playerContext.CanMove = false;
        playerContext.Anim.Play("Jump");
        playerContext.Grounded = false;
        playerContext.RB.AddForce(Vector2.up * playerContext.JumpForce, ForceMode2D.Impulse);
        playerContext.AppliedMovementX = 0f;
        playerContext.AppliedMovementY = 0f;
    }
    public override void UpdateState()
    {
        Debug.Log("in jump state");
        //playerContext.CanMove = true;
        //playerContext.AppliedMovementY = 0f;
        //playerContext.AppliedMovementX = playerContext.CurrentMovementInput.x * playerContext.MoveSpeed / 3f;
        //playerContext.AppliedMovementX = playerContext.CurrentMovementInput.x * playerContext.MoveSpeed;
        playerContext.AppliedMovementY = 0f ;
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.CanMove = true;
        playerContext.AppliedMovementY = 0f;
        //playerContext.Grounded = true;
    }

    public override void CheckSwitchStates()
    {
        // if (playerContext.IsHurt)
        // {
        //     SwitchState(new PlayerHurtState(playerContext));
        // } else if (playerContext.Grounded && !playerContext.IsMovementPressed )
        // {
        //     Debug.Log("switching to idle");
        //     SwitchState(new PlayerIdleState(playerContext));
        // } else if (playerContext.Grounded && !playerContext.IsRunPressed)
        // {
        //     SwitchState(new PlayerWalkState(playerContext));
        // } else if (playerContext.Grounded && playerContext.IsRunPressed)
        // {
        //     SwitchState(new PlayerRunState(playerContext));
        // }
        if (playerContext.Grounded)
        {
            SwitchState(new PlayerIdleState(playerContext));
        }
    }
}
