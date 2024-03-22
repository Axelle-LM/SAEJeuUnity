using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuBehaviour : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
