using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    PlayerMovement movement;

    // Update is called once per frame
    void Update()
    {
        SetMovementValue();
    }

    void SetMovementValue()
    {
        int value = 0;
        switch (movement.Direction)
        {
            case PlayerMovement.PlayerDirection.NORTH:
            case PlayerMovement.PlayerDirection.NORTH_EAST:
            case PlayerMovement.PlayerDirection.NORTH_WEST:
                value = 1;
                break;
            case PlayerMovement.PlayerDirection.WEST:
                value = 4;
                break;
            case PlayerMovement.PlayerDirection.EAST:
                value = 2;
                break;
            case PlayerMovement.PlayerDirection.SOUTH:
            case PlayerMovement.PlayerDirection.SOUTH_WEST:
            case PlayerMovement.PlayerDirection.SOUTH_EAST:
                value = 3;
                break;
        }
        if (value != 0)
        {
            animator.SetInteger("Direction", value);
        }

    }
}
