using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger3 : MonoBehaviour
{
    [SerializeField]
    GameObject door = null;

    [SerializeField]
    GameObject ennemy = null;

    private bool doorIsClosed = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!doorIsClosed)
        {
            transform.position -= new Vector3(0, 0.26f, 0);//move down platform
            door.transform.position -= new Vector3(0, 15, 0);//close the door
            doorIsClosed = true;
            Destroy(ennemy);
        }
    }
}
