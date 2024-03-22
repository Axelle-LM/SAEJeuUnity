using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletForce = 200f;

    public Camera mainCamera;
    public float zoomAmount = 0.5f; // Montant du zoom

    PlayerInput playerInput;
    InputAction shootAction;
    bool isZooming = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        shootAction = playerInput.actions.FindAction("Shoot");
    }

    void Update()
    {
        if (shootAction.triggered)
        {
            Shoot();
        }

        if (shootAction.phase == InputActionPhase.Started)
        {
            isZooming = true;
            ZoomCamera();
        }
        else if (shootAction.phase == InputActionPhase.Canceled)
        {
            isZooming = false;
            ZoomCamera();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var rb = bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
    
        
    }
}
