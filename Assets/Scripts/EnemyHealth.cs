using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int m_enemyHealth = 2;

    // Update is called once per frame
    void Update()
    {
        killEnemy();
    }

    void killEnemy()
    {
        if (m_enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
