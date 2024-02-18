using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
         playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (playerHealth != null)
        {
            playerHealth.playerHealth -= 1;
        }
    }
}
