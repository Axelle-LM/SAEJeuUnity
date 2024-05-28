using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateSpawner : MonoBehaviour
{
    [SerializeField] private Spawner m_spawner;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && m_spawner != null)
        {
            m_spawner.gameObject.SetActive(true);
        }
    }
}
