using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Configurações de Sensibilidade")]
    [SerializeField] private float mouseSensitivity = 2f;

    [Header("Limites de Ângulo (Vertical)")]
    [SerializeField] private float minY = -30f;
    [SerializeField] private float maxY = 60f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
   
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        
        Vector2 mouseDelta = Vector2.zero;
        if (Mouse.current != null)
        {
            mouseDelta = Mouse.current.delta.ReadValue() * 0.1f * mouseSensitivity;
        }

        float mouseX = mouseDelta.x;
        float mouseY = mouseDelta.y;

       
        rotationY += mouseX;
        rotationX -= mouseY;

      
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

     
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);

       
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}