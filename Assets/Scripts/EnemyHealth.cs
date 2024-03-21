using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 2;
    [SerializeField] private Spawner spawner;

    // Update is called once per frame
    void Update()
    {
        killEnemy();
    }

    void killEnemy()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
