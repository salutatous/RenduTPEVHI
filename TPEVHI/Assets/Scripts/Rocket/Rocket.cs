using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public float speed = 20.0f;

    public float lifeTime = 1.5f;

    void Start()
    {
        Invoke("Kill", lifeTime);
    }
    
    void Update()
    {
        transform.position += transform.forward*speed*Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ennemy" || collider.tag == "Player" || collider.tag == "Boss")//damage only ennemy and player
        {
            Health health = collider.gameObject.GetComponent<Health>();
            health.TakeDamage(1);
        }
        Kill();
    }
    
    void Kill()
    {
        Destroy(gameObject);
    }
}
