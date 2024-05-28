using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBarrier : MonoBehaviour
{
    [SerializeField] private Spawner m_spawner;

    // Update is called once per frame
    void Update()
    {
        if (m_spawner != null)
        {
            if (m_spawner.m_isFinished)
            {
                Destroy(gameObject);
            }
        }
    }
}
