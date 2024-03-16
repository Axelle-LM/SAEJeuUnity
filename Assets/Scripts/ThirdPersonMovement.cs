using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float moveSpeed = 5f;
    private Vector2 direction;
    private Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("No camera");
        }
    }

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if (m_Rigidbody == null)
        {
            m_Rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (cam != null)
        {

            Vector3 moveDirection = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * new Vector3(direction.x, 0f, direction.y);

            Quaternion moveRotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);

            m_Rigidbody.MovePosition(m_Rigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
            m_Rigidbody.MoveRotation(Quaternion.Lerp(m_Rigidbody.rotation, moveRotation, 10.0f * Time.fixedDeltaTime));

        }
        else
        {
            Debug.LogWarning("No camera found.");
        }
    }

    public void OnToggleMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}