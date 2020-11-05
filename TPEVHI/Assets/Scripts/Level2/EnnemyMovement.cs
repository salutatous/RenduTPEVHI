using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    public float maxValueX = 10.0f;
    public float minValueX = -10.0f;
    private float currentValueX = 0f;
    private float speed = 4.0f;
    //duration of the rotation of the gameObject -> in sec
    private float remainingTimeToRotate = 0f;

    [SerializeField]
    Animator anim = null;

    void Start(){
        currentValueX = minValueX;
    }

    void Update(){
        anim.SetFloat("move", 1);
        currentValueX += Time.deltaTime*speed;
        if(currentValueX > maxValueX)//gameObject will go to the left
        {
            currentValueX = maxValueX;
            speed *= -1;//change direction
            remainingTimeToRotate = 1;
        }
        else if(currentValueX < minValueX)//gameObject will go to the right
        {
            currentValueX = minValueX;
            speed *= -1;//change direction
            remainingTimeToRotate = 1;
        }
        if(remainingTimeToRotate > 0)
        {
            transform.Rotate(0, 180*Time.deltaTime, 0);
            remainingTimeToRotate -= Time.deltaTime;
        }
        transform.position = new Vector3(currentValueX, transform.position.y, transform.position.z);
    }
}
