using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLight : MonoBehaviour
{
    [SerializeField]
    Light[] lights = null;

    [SerializeField]
    GameObject boss = null;

    [SerializeField]
    public Health health = null;

    [SerializeField]
    public GameObject door = null;

    public GameObject door2 = null;
    public GameObject door3 = null;

    private bool lightsAreActivated = false;

    void OnTriggerEnter(Collider collider)
    {
        if(!lightsAreActivated)
        {
            lightsAreActivated = true;
            foreach(Light light in lights)//enable every lights
            {
                light.enabled = true;
            }
            InstantiateBoss();//make the boss appear
            door.transform.position += new Vector3(0, 32, 0);//close the door behind us
            door2.transform.position += new Vector3(8, 0, 0);
            door3.transform.position -= new Vector3(8, 0, 0);
            transform.position -= new Vector3(0, 0.26f, 0);
        }
    }

    void InstantiateBoss()
    {
        GameObject bossObject = Instantiate(boss, new Vector3(0,0,60), Quaternion.Euler(0, 180, 0));
        bossObject.transform.localScale = new Vector3(3, 3, 3);
        bossObject.GetComponent<BossFollow>().setPlayerHealth(health);
    }
}
