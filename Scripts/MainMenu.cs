using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        PauseMenu.isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("you have quit the game");
    }
}
