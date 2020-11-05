using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch4 : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
         SceneManager.LoadScene(5);
    }
}
