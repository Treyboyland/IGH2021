using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    PlayerMovement movement;

    [SerializeField]
    DirectionVector3Event onThrowAtLocation;

    public void HandleThrow(InputAction.CallbackContext context)
    {
        //Debug.LogWarning("Throw: Performed" + context.performed + " HasBall: " + player.HasBall);
        if (context.performed && player.HasBall)
        {
            player.HasBall = false;
            onThrowAtLocation.Value1 = movement.Direction;
            onThrowAtLocation.Value2 = player.transform.position;
            onThrowAtLocation.Invoke();
        }
    }



}
