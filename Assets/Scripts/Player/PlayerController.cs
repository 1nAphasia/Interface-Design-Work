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
    public Camera Cam;
    private Vector3 CamForward;
    private Vector3 CamRight;
    private bool jumpPressed;
    private bool attackPressed;
    private CharacterController controller;
    private PlayerData playerData;

    void Awake()
    {
        stateMachine = new StateMachine();
        IdleState = new PlayerIdleState(this, stateMachine);
        RunState = new PlayerRunState(this, stateMachine);
        AimState = new PlayerAimState(this, stateMachine);
        controls = new PlayerControls();
        Cam = Camera.main;
        controller = GetComponent<CharacterController>();
        playerData = GetComponent<PlayerData>();
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
        GetCamDir();
        if (MoveInput != Vector2.zero)
        {
            Vector3 move = (CamForward * moveInput.y + CamRight * moveInput.x) * Time.deltaTime * playerData.MoveSpeed;
            controller.Move(move);
        }
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
    private void GetCamDir()
    {
        CamForward = Cam.transform.forward;
        CamRight = Cam.transform.right;
        CamForward.y = 0;
        CamRight.y = 0;
        CamForward.Normalize();
        CamRight.Normalize();
    }
}