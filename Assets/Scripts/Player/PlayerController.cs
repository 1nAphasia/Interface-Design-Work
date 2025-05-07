using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
public class PlayerController : MonoBehaviour
{
    public Animator Animator;

    public Vector2 MoveInput => moveInput;
    public bool JumpPressed => jumpPressed;
    public StateMachine stateMachine;

    // 各状态实例
    public PlayerIdleState IdleState;
    public PlayerRunState RunState;
    public PlayerAimState AimState;

    private PlayerControls controls;
    private Vector2 moveInput;
    private Camera cam;

    private bool jumpPressed;
    private bool attackPressed;

    void Awake()
    {
        stateMachine = new StateMachine();
        IdleState = new PlayerIdleState(this, stateMachine);
        RunState = new PlayerRunState(this, stateMachine);
        AimState = new PlayerAimState(this, stateMachine);
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.KeyboardMouse.Enable();
    }
    void Start()
    {
        stateMachine.ChangeState(IdleState);
    }
    void OnDisable()
    {
        controls.KeyboardMouse.Disable();
    }
    void Update()
    {
        GetMoveInput();
        GetJumpInput();

        stateMachine.Tick();
    }

    private void GetMoveInput()
    {
        moveInput = controls.KeyboardMouse.Move.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            Debug.Log(moveInput);
        }
    }

    private void GetJumpInput()
    {
        jumpPressed = controls.KeyboardMouse.Jump.IsPressed();
    }

}