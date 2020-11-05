using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch3 : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
         SceneManager.LoadScene(4);
    }
}
