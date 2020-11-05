using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch1 : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
         SceneManager.LoadScene(2);
    }
}
