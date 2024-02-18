using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // En développement, pas finit
    public GameObject enemyPrefab;
    public int amountToKill = 2;
    public int maxEnemies = 2;

    private int currentEnemies = 0;

    // Update is called once per frame
    void Update()
    {
        // Vérifiez si le nombre actuel d'ennemis sur le terrain est inférieur au nombre souhaité
        if (currentEnemies < amountToKill)
        {
            // Générez un ennemi
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            currentEnemies++;
        }
    }
}
