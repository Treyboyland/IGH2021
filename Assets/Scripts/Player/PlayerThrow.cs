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
    DirectionPlayerEvent onThrowAtLocation;

    [SerializeField]
    bool infiniteBalls;

    public void HandleThrow(InputAction.CallbackContext context)
    {
        //Debug.LogWarning("Throw: Performed" + context.performed + " HasBall: " + player.HasBall);
        if (context.performed && (player.HasBall || infiniteBalls))
        {
            player.HasBall = false;
            onThrowAtLocation.Value1 = movement.Direction;
            onThrowAtLocation.Value2 = player;
            onThrowAtLocation.Invoke();
        }
    }



}
