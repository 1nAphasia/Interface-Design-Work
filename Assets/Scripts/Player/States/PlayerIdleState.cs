using UnityEngine;
public class PlayerIdleState : State
{
    public PlayerIdleState(PlayerController player, StateMachine stateMachine)
        : base(player, stateMachine) { }

    public override void Enter()
    {
        player.Animator.Play("Idle");
    }

    public override void Tick()
    {
        if (player.MoveInput != Vector2.zero)
            stateMachine.ChangeState(player.RunState);
    }

    public override void Exit() { }
}
