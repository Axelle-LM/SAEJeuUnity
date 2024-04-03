using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameBehaviour : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
