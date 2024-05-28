using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private GameObject m_collectible1Prefab;
    [SerializeField] private GameObject m_collectible2Prefab;

    private List<GameObject> m_enemies = new List<GameObject>();

    [SerializeField] private int m_amountOfEnemyToKill = 10;
    [SerializeField] private int m_maxEnemiesOnField = 3;

    private int m_amountOfEnemyKilled = 0;

    [NonSerialized] public bool m_isFinished = false;

    void Update()
    {
        if (m_amountOfEnemyKilled < m_amountOfEnemyToKill)
        {
            if (m_enemies.Count < m_maxEnemiesOnField)
            {
                GameObject newEnemy = Instantiate(m_enemyPrefab, transform.position, Quaternion.identity);
                m_enemies.Add(newEnemy);
            }

            // Vérifie si un ennemi a été tué
            foreach (GameObject enemy in m_enemies)
            {
                if (enemy == null)
                {
                    m_amountOfEnemyKilled++;
                    m_enemies.Remove(enemy);
                    break;
                }
            }

            // Si le nombre d'ennemis tués atteint le nombre requis
            if (m_amountOfEnemyKilled >= m_amountOfEnemyToKill)
            {
                // Fait apparaitre les collectibles à la position du dernier ennemi tué
                if (m_collectible1Prefab != null) { Instantiate(m_collectible1Prefab, transform.position, Quaternion.identity); }
                if (m_collectible2Prefab != null) { Instantiate(m_collectible2Prefab, transform.position, Quaternion.identity); }
                m_isFinished = true;
            }
        }
    }
}
