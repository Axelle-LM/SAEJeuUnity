using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuBehaviour : MonoBehaviour
{
    public void returnToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
