using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] float speed = 5;
    private Transform cam;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Movement");

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("No camera");
        }
        
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (direction.magnitude >= 0.1f && cam != null)
        {
           
            Vector3 moveDirection = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * new Vector3(direction.x, 0f, direction.y);

            transform.position += moveDirection.normalized * speed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);
        }
    }
}
