using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public static bool isActivated = false;

    public GameObject victoryMenu;

    void Update()
    {
        if(isActivated){
            Cursor.lockState = CursorLockMode.None;
            victoryMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
