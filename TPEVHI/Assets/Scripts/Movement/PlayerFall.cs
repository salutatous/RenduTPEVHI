using System.Collections;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    [SerializeField]
    Health health = null;

    [SerializeField]
    CharacterController controller = null;

    void Update()
    {
        if(transform.position.y <= -50)
        {
            controller.enabled = false;
            transform.position = Vector3.zero;
            controller.enabled = true;
            health.TakeDamage(1);
        }
    }
}
