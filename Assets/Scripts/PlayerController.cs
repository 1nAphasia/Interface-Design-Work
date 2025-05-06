using UnityEngine
public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public PlayerInput Input; // 自定义输入组件

    public StateMachine stateMachine;

    // 各状态实例
    public PlayerIdleState IdleState;
    public PlayerRunState RunState;
    public PlayerAttackState AttackState;

    void Awake()
    {
        stateMachine = new StateMachine();
        IdleState = new PlayerIdleState(this, stateMachine);
        RunState = new PlayerRunState(this, stateMachine);
        AttackState = new PlayerAttackState(this, stateMachine);
    }

    void Start()
    {
        stateMachine.ChangeState(IdleState);
    }

    void Update()
    {
        stateMachine.Tick();
    }
}