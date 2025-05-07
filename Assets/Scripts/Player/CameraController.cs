using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 cameraInput;
    public Vector2 CameraInput => cameraInput;
    public Transform player; // 玩家Transform
    public float mouseSensitivity = 50f; // 鼠标灵敏度
    public float smoothTime = 0.1f; // 平滑旋转时间
    public float verticalLookUpLimit = 80f;
    public float verticalLookDownLimit = -60f; // 垂直旋转的限制（防止摄像机翻转）
    public float disToPlayer = 5.0f;
    public float offsetToSide = 2.0f;
    public float offsetToUp = 2.0f;


    private float currentPitch = 0f; // 当前的竖直角度
    private float currentYaw = 0f; // 当前的水平角度

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.KeyboardMouse.Enable();
    }

    void OnDisable()
    {
        controls.KeyboardMouse.Disable();
    }

    void Update()
    {
        GetCameraInput();
        if (cameraInput != Vector2.zero)
        {
            currentYaw += cameraInput.x * mouseSensitivity * Time.deltaTime;
            currentPitch -= cameraInput.y * mouseSensitivity * Time.deltaTime;
            currentPitch = Mathf.Clamp(currentPitch, verticalLookDownLimit, verticalLookUpLimit);
            transform.eulerAngles = new Vector3(currentPitch, currentYaw, 0f);
            // 让摄像机跟随玩家
            transform.position = player.position - transform.forward * disToPlayer + transform.up * offsetToUp + transform.right * offsetToSide; // 保持一定的距离
        }
    }

    private void GetCameraInput()
    {
        cameraInput = controls.KeyboardMouse.CameraControl.ReadValue<Vector2>();
        if (cameraInput != Vector2.zero)
        {
            Debug.Log("Current Camera Input = " + cameraInput.ToString());
        }
    }
}