using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 使用 Unity 新输入系统的输入类（需要 Input System 包）
/// </summary>
public class PlayerInput : MonoBehaviour
{
    // 存储输入的值（字段）
    private Vector2 moveInput;
    private bool jumpPressed;
    private bool attackPressed;

    /// <summary>
    /// 公有属性供外部访问输入值（相当于 get 方法）
    /// </summary>
    public Vector2 Move => moveInput;
    public bool JumpPressed => jumpPressed;
    public bool AttackPressed => attackPressed;

    /// <summary>
    /// 新输入系统的事件回调方法，用于读取移动方向（由InputAction绑定）
    /// context.ReadValue<Vector2>() 是泛型方法，表示读取输入值并解析为 Vector2 类型
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// 监听跳跃输入的按下/释放（performed 表示按下，canceled 表示松开）
    /// </summary>
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpPressed = true;

        if (context.canceled)
            jumpPressed = false;
    }

    /// <summary>
    /// 监听攻击输入（例如鼠标左键或手柄攻击键）
    /// </summary>
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            attackPressed = true;

        if (context.canceled)
            attackPressed = false;
    }

    /// <summary>
    /// Unity 的生命周期函数之一，类似游戏循环中的 late update。
    /// 在每一帧的最后阶段清除瞬时按钮状态，防止多次触发。
    /// </summary>
    private void LateUpdate()
    {
        attackPressed = false;
        jumpPressed = false;
    }
}
