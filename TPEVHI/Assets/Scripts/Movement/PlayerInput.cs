using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetMovementInput();
        GetMovementDirection();
    }

    void GetMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMovementInput?.Invoke(input);
    }

    void GetMovementDirection()
    {
        var cameraForwardDirection = Camera.main.transform.forward;
        var directionToMoveIn = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        OnMovementDirectionInput?.Invoke(directionToMoveIn);
    }
}
