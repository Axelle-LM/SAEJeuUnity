using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int m_damageTakenByEnemy = 1;

    [SerializeField] private GameObject m_enemy;
    [SerializeField] private Spawner m_spawner;

    void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth m_enemyHealthComponent = _collision.gameObject.GetComponent<EnemyHealth>();
            RemoveHealthFromEnemy(m_enemyHealthComponent, m_damageTakenByEnemy);
        }
        Destroy(gameObject);
    }


    void RemoveHealthFromEnemy(EnemyHealth _enemyHealthComponent, int _damageTaken)
    {
        if (_enemyHealthComponent.m_enemyHealth > 0)
        {
            _enemyHealthComponent.m_enemyHealth -= _damageTaken;
        }
    }
}
