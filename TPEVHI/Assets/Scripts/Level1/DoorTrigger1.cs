using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger1 : MonoBehaviour
{
    [SerializeField]
    GameObject door = null;

    private bool doorIsOpen = false;

    void OnTriggerEnter(Collider col)
    {
        if (!doorIsOpen)
        {
            transform.position -= new Vector3(0, 0.26f, 0);
            door.transform.position += new Vector3(0, 15, 0);
            doorIsOpen = true;
        }
    }
}
