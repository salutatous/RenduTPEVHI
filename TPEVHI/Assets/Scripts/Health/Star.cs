using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<Health>().Invincible();
            Destroy(gameObject);
        }
    }
}
