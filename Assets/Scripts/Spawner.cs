using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Prefabs
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject collectible1Prefab;
    [SerializeField] private GameObject collectible2Prefab;

    private List<GameObject> enemies = new List<GameObject>();

    //Config du spawner
    [SerializeField] private int amountOfEnemyToKill = 10;
    [SerializeField] private int maxEnemiesOnField = 3;

    //Pas touche
    private int amountOfEnemyKilled = 0;

    void Update()
    {
        if (amountOfEnemyKilled < amountOfEnemyToKill)
        {
            if (enemies.Count < maxEnemiesOnField)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemies.Add(newEnemy);
            }

            // Vérifie si un ennemi a été tué
            foreach (GameObject enemy in enemies)
            {
                if (enemy == null)
                {
                    amountOfEnemyKilled++;
                    enemies.Remove(enemy);
                    break;
                }
            }

            // Si le nombre d'ennemis tués atteint le nombre requis
            if (amountOfEnemyKilled >= amountOfEnemyToKill)
            {
                // Fait apparaitre les collectibles à la position du dernier ennemi tué
                Instantiate(collectible1Prefab, transform.position, Quaternion.identity);
                Instantiate(collectible2Prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
