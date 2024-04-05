using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(newCam);
            Debug.Log("Nouvelle caméra activée : " + newCam.name);
        }
    }
}
