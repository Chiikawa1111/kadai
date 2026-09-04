using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;

    private float currentSpeed = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) move.z += 1f;
        if (Keyboard.current.sKey.isPressed) move.z -= 1f;
        if (Keyboard.current.dKey.isPressed) move.x += 1f;
        if (Keyboard.current.aKey.isPressed) move.x -= 1f;

        move = move.normalized;

        // 常に走り状態
        currentSpeed = runSpeed;

        if (move.magnitude >= 0.1f)
        {
            // カメラ方向ベースで移動
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;

            Vector3 moveDir = forward * move.z + right * move.x;

            transform.position += moveDir * currentSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed = 0.0f;
        }

        // 攻撃アニメーション（左クリック）
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }

        // アニメーションの速度更新
        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }
    }
}
