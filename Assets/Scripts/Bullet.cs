using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageTakenByEnemy = 1;

    [SerializeField] private GameObject enemy;
    private CapsuleCollider enemyCollider;
    private EnemyHealth enemyHealthComponent;
    [SerializeField] private Spawner spawner;

    void Awake()
    {   
        if (enemy != null)
        {
            enemyCollider = enemy.GetComponent<CapsuleCollider>();
            enemyHealthComponent = enemy.GetComponent<EnemyHealth>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("touché coulé");
            EnemyHealth enemyHealthComponent = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealthComponent != null)
            {
                RemoveHealthFromEnemy(enemyHealthComponent, damageTakenByEnemy);
            }
        }
        Destroy(gameObject);
    }


    void RemoveHealthFromEnemy(EnemyHealth enemyHealthComponent, int damageTaken)
    {
        if (enemyHealthComponent.enemyHealth > 0)
        {
            enemyHealthComponent.enemyHealth -= damageTaken;
        }
    }
}
