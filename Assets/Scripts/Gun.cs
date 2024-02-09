using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
public Transform bulletSpawnPoint;
public GameObject bulletPrefab;
public float bulletForce = 10f;
// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var rb = bullet.AddComponent<Rigidbody>();
        // rb.useGravity = true;
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
        
        Destroy(bullet, 2); // Détruire la balle après 2 secondes
    }
    
}

}