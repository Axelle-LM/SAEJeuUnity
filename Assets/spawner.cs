using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // En d�veloppement, pas finit
    public GameObject enemyPrefab;
    public int amountToKill = 2;
    public int maxEnemies = 2;

    private int currentEnemies = 0;

    // Update is called once per frame
    void Update()
    {
        // V�rifiez si le nombre actuel d'ennemis sur le terrain est inf�rieur au nombre souhait�
        if (currentEnemies < amountToKill)
        {
            // G�n�rez un ennemi
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            currentEnemies++;
        }
    }
}
