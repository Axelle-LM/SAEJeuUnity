using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private CapsuleCollider playerCollider;
    private PlayerHealth playerHealthComponent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<CapsuleCollider>();
        playerHealthComponent = player.GetComponent<PlayerHealth>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider)
        {
            removeHealthFromPlayer(playerHealthComponent, 1);
        }
        Destroy(gameObject);
    }
    void removeHealthFromPlayer(PlayerHealth playerHealthComponent, int damageTaken)
    {
        if (playerHealthComponent.playerHealth > 0)
        {
            playerHealthComponent.playerHealth -= damageTaken;
        }
    }
}
