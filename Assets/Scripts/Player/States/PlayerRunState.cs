using UnityEngine;
public class PlayerRunState : State
{
    public PlayerRunState(PlayerController player, StateMachine stateMachine)
        : base(player, stateMachine) { }

    public override void Enter()
    {
        player.Animator.Play("Run");
    }

    public override void Tick()
    {

    }

    public override void Exit() { }
}
