using UnityEngine;

public abstract class State : IState
{
    protected PlayerController player;
    protected StateMachine stateMachine;

    public State(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit();
}
