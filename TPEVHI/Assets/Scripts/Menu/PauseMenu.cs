using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }        
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void RestartLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit(){
        pauseMenu.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}
