using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    GameObject rocketPrefab = null;
    
    [SerializeField]
    Transform rocketBarrel = null;

    [SerializeField]
    float reloadTime = 0.5f;
    
    private float lastFireTime;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && (Time.time > lastFireTime+reloadTime))
        {
            GameObject go = (GameObject)Instantiate(rocketPrefab,
                rocketBarrel.position+rocketBarrel.forward, 
                Quaternion.LookRotation(rocketBarrel.forward));
            Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
            go.GetComponent<Renderer>().material.color = Color.blue;
            lastFireTime = Time.time;
        }
    }
}