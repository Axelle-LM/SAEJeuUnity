using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRegiter : MonoBehaviour
{
   private void OnEnable()
   {
       CameraSwitcher.Register(GetComponent<CinemachineVirtualCamera>());
   }

    private void OnDisable()
    {
         CameraSwitcher.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}
