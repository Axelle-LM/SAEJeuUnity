using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // En développement, pas finit
    public GameObject enemyPrefab;
    public int amountToKill = 10;
    public int enemySpawnedSinceStart = 0;
    public int maxEnemies = 2;
    public int currentEnemies = 0;

    // Update is called once per frame
    void Update()
    {
        if (enemySpawnedSinceStart < amountToKill)
        {
            if (currentEnemies < maxEnemies)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemySpawnedSinceStart++;
                currentEnemies++;
            }
        }
    }
}
