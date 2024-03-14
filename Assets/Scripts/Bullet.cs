using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public int damage = 1; // Dégâts infligés au joueur

    private GameObject player;
    private CapsuleCollider playerCollider;
    private PlayerHealth playerHealthComponent;

    void Awake()
    {
        Destroy(gameObject, life);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerCollider = player.GetComponent<CapsuleCollider>();
            playerHealthComponent = player.GetComponent<PlayerHealth>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider && playerHealthComponent != null)
        {
            RemoveHealthFromPlayer(playerHealthComponent, damage);
        }
        Destroy(gameObject);
    }

    void RemoveHealthFromPlayer(PlayerHealth playerHealthComponent, int damageTaken)
    {
        if (playerHealthComponent.playerHealth > 0)
        {
            playerHealthComponent.playerHealth -= damageTaken;
        }
    }
}
