using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 direction;

    void Awake()
    {
        if (m_Rigidbody == null)
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            if (m_Rigidbody == null)
            {
                m_Rigidbody = gameObject.AddComponent<Rigidbody>();
            }
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Déplacement du personnage
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        m_Rigidbody.MovePosition(m_Rigidbody.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.fixedDeltaTime);

        // Rotation du personnage en direction de la souris
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y; // Assurez-vous que la hauteur est la même que celle du personnage
            Vector3 lookDirection = targetPosition - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            m_Rigidbody.MoveRotation(Quaternion.Lerp(m_Rigidbody.rotation, lookRotation, 10.0f * Time.fixedDeltaTime));
        }
    }

    public void OnToggleMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
