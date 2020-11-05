using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
        collider.GetComponent<Health>().GainLife();
        Destroy(gameObject);
        }
    }
}
