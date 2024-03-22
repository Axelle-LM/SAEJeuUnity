using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonBehaviour : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void leaveGame()
    {
        Application.Quit();
    }
}
