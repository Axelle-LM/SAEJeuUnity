using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject m_player;
    private CapsuleCollider m_playerCollider;
    private PlayerHealth m_playerHealthComponent;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_playerCollider = m_player.GetComponent<CapsuleCollider>();
        m_playerHealthComponent = m_player.GetComponent<PlayerHealth>();
    }


    void OnCollisionEnter(Collision _collision)
    {
        if (_collision.collider == m_playerCollider)
        {
            removeHealthFromPlayer(m_playerHealthComponent, 1);
        }
        Destroy(gameObject);
    }
    void removeHealthFromPlayer(PlayerHealth _playerHealthComponent, int _damageTaken)
    {
        if (_playerHealthComponent.m_playerHealth > 0) //vasy jpppp bof je souffre tro berk je vais dégueuler si je bois
        {
            _playerHealthComponent.m_playerHealth -= _damageTaken;
        }
    }
}
