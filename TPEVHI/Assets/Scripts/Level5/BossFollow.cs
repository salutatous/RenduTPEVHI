using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossFollow : MonoBehaviour, IPlayerInput
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    public LayerMask playerLayer;
    public Transform playerTransform;
    public Health playerHealth;
    public float visionDistance = 40;
    public float stoppingDistance = 3.2f;

    private bool playerDetectionResult = false;

    public void setPlayerHealth(Health health)
    {
        playerHealth = health;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(playerDetectionResult)
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, visionDistance);
    }

    private bool DetectPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, visionDistance, playerLayer);
        foreach(var collider in hitColliders)
        {
            playerTransform = collider.transform;
            return true;
        }
        playerTransform = null;
        return false;
    }

    void Update()
    {
        playerDetectionResult = DetectPlayer();
        if(playerDetectionResult)
        {
            var directionToPlayer = playerTransform.position-transform.position;
            directionToPlayer = Vector3.Scale(directionToPlayer, Vector3.forward+Vector3.right);
            if (directionToPlayer.magnitude > stoppingDistance)
            {
                directionToPlayer.Normalize();
                OnMovementInput?.Invoke(Vector2.up);
                OnMovementDirectionInput?.Invoke(directionToPlayer);
                return;
            }
            playerHealth.TakeDamage(3);
        }
        OnMovementInput?.Invoke(Vector2.zero);
        OnMovementDirectionInput?.Invoke(transform.forward);
    }
}