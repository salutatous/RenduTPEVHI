using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger2 : MonoBehaviour
{
    [SerializeField]
    GameObject door = null;

    [SerializeField]
    GameObject ennemy = null;

    private bool doorIsOpen = false;

    void OnTriggerEnter(Collider col)
    {
        //wait for the ennemy to die before the trigger can be activated
        if (!doorIsOpen && ennemy==null)
        {
            transform.position -= new Vector3(0, 0.26f, 0);
            door.transform.position += new Vector3(0, 15, 0);
            doorIsOpen = true;
        }
    }
}
