using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerInput input;
    private PlayerMovement movement;

    void OnEnable(){
        input = GetComponent<IPlayerInput>();
        movement = GetComponent<PlayerMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    void OnDisable()
    {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }
}
