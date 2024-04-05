using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class CameraTriggerVolume : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Vector3 boxSize;

    private BoxCollider box;
    private Rigidbody rb;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        box.isTrigger = true;
        box.size = boxSize;
        rb.isKinematic = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Si oui, activez la caméra
            if (CameraSwitcher.ActiveCamera != cam)
            {
                CameraSwitcher.SwitchCamera(cam);
                Debug.Log("Caméra activée : " + cam.name);
            }
        }
        else
        {
            // Si ce n'est pas le joueur, ignorez l'événement
            return;
        }
    }
}
