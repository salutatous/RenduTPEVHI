using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch2 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
         SceneManager.LoadScene(3);
    }
}
