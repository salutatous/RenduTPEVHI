using System.Collections;
using UnityEngine;

public class FalseTrigger : MonoBehaviour
{
    private bool platformIsActivated = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!platformIsActivated)
        {
            transform.position -= new Vector3(0, 0.26f, 0);
            platformIsActivated = true;
        }
    }
}