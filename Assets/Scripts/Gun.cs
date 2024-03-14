using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletForce = 1000f;

    PlayerInput playerInput;
    InputAction shootAction;

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
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var rb = bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
        
        Destroy(bullet, 2); // Détruire la balle après 2 secondes
    }
}
