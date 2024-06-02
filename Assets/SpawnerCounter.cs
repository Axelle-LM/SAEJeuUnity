using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerCounter : MonoBehaviour
{
    public Spawner spawner;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = spawner.m_name + " : " + spawner.m_amountOfEnemyKilled + "/" + spawner.m_amountOfEnemyToKill;
    }
}
