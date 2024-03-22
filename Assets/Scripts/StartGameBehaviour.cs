using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBehaviour : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
