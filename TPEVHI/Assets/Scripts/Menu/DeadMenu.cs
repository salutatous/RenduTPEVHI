using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject deadMenu;

    public static bool gameIsPaused = false;

    void Update()
    {
        if(gameIsPaused)
        {
            Pause();
        }
    }

    void Pause(){
        Cursor.lockState = CursorLockMode.None;
        deadMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Yes(){
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        deadMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void No(){
        SceneManager.LoadScene(0);
        deadMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
