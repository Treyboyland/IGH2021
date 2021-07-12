using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    public enum PlayerDirection
    {
        NONE,
        NORTH,
        SOUTH,
        EAST,
        WEST,
        NORTH_EAST,
        NORTH_WEST,
        SOUTH_EAST,
        SOUTH_WEST
    }


    Vector2 movement;

    Vector2 lastNonZeroValue = new Vector2();

    public PlayerDirection Direction
    {
        get
        {
            return GetCurrentDirection();
        }
    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        //NOTE: Only called when value changes, not when held (e.g. a button)
        //Debug.LogWarning(gameObject.name + ": " + context);
        movement = context.ReadValue<Vector2>();
        if (movement != new Vector2())
        {
            lastNonZeroValue = movement;
        }
    }


    private void Update()
    {
        Move(movement);
    }

    PlayerDirection GetCurrentDirection()
    {
        // if (movement == new Vector2())
        // {
        //     return PlayerDirection.NONE;
        // }
        var movement = lastNonZeroValue;

        if (movement.x == 0)
        {
            return movement.y < 0 ? PlayerDirection.SOUTH : PlayerDirection.NORTH;
        }
        if (movement.y == 0)
        {
            return movement.x < 0 ? PlayerDirection.WEST : PlayerDirection.EAST;
        }

        if (movement.x > 0)
        {
            return movement.y < 0 ? PlayerDirection.SOUTH_EAST : PlayerDirection.NORTH_EAST;
        }
        else
        {
            return movement.y < 0 ? PlayerDirection.SOUTH_WEST : PlayerDirection.NORTH_WEST;
        }
    }
}
