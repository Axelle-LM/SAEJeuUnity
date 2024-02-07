using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePosition;
    public float speed = 10f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePosition.position, Quaternion.identity);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit: " + collision.transform.name);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
