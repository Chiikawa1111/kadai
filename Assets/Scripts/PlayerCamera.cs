using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCamera : MonoBehaviour

{
    [SerializeField] private Transform playerBody; // キャラ本体
    [SerializeField] private float mouseSensitivity = 200f;

    private float xRotation = 0f;

    void Start()
    {
        // カーソルをロック（FPS風）
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouseInput = Mouse.current.delta.ReadValue();

        float mouseX = mouseInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseInput.y * mouseSensitivity * Time.deltaTime;

        // 上下回転（カメラのみ）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 左右回転（キャラ本体）
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
