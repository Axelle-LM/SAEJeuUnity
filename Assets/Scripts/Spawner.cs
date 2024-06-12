using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public string m_name;
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private GameObject m_collectible1Prefab;
    [SerializeField] private GameObject m_collectible2Prefab;

    [SerializeField] private GameObject m_spawnerCounter;

    private List<GameObject> m_enemies = new List<GameObject>();

    public int m_amountOfEnemyToKill = 10;
    [SerializeField] private int m_maxEnemiesOnField = 3;

    [NonSerialized] public int m_amountOfEnemyKilled = 0;

    [NonSerialized] public bool m_isFinished = false;

    private int randomMin = -5;
    
    private int randomMax = 5;

    void Update()
    {
        if (m_amountOfEnemyKilled < m_amountOfEnemyToKill)
        {
            if (m_enemies.Count < m_maxEnemiesOnField)
            {
                int randomNumber = UnityEngine.Random.Range(randomMin, randomMax);
                GameObject newEnemy = Instantiate(m_enemyPrefab, new Vector3(transform.position.x+randomNumber, transform.position.y, transform.position.z+randomNumber), Quaternion.identity);
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
                // Fait apparaitre les collectibles
                if (m_collectible1Prefab != null) { Instantiate(m_collectible1Prefab, transform.position, Quaternion.identity); }
                if (m_collectible2Prefab != null) { Instantiate(m_collectible2Prefab, transform.position, Quaternion.identity); }
                m_isFinished = true;
                m_spawnerCounter.SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collider collider)
    {
        if (collider.tag == "Prop")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
