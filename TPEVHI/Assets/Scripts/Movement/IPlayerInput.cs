using System;
using UnityEngine;

public interface IPlayerInput
{
    Action<Vector2> OnMovementInput { get; set; }
    Action<Vector3> OnMovementDirectionInput { get; set; }
}