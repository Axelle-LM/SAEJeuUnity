using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateSpawner : MonoBehaviour
{
    [SerializeField] private Spawner m_spawner;
    [SerializeField] private GameObject m_spawnerCounter;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && m_spawner != null)
        {
            m_spawner.gameObject.SetActive(true);
            if (m_spawner.m_isFinished != true)
            {
                m_spawnerCounter.SetActive(true);
            }
        }
    }
}
