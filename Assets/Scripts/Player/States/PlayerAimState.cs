using UnityEngine;
public class PlayerAimState : State
{
    public PlayerAimState(PlayerController player, StateMachine stateMachine)
        : base(player, stateMachine) { }

    public override void Enter()
    {
        player.Animator.Play("Aim");
    }

    public override void Tick()
    {

    }

    public override void Exit() { }
}
