using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float magnitudeThreshold;

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3Event onStopLocation;

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.sqrMagnitude < magnitudeThreshold)
        {
            Debug.LogWarning("Stopping object");
            onStopLocation.Value = transform.position;
            onStopLocation.Invoke();
            gameObject.SetActive(false);
        }
    }


    public void SetInitialVelocity(PlayerMovement.PlayerDirection direction)
    {
        Vector2 angle = new Vector2();

        switch (direction)
        {
            case PlayerMovement.PlayerDirection.NORTH:
            case PlayerMovement.PlayerDirection.NORTH_EAST:
            case PlayerMovement.PlayerDirection.NORTH_WEST:
                angle.y = 1;
                break;
            case PlayerMovement.PlayerDirection.SOUTH:
            case PlayerMovement.PlayerDirection.SOUTH_EAST:
            case PlayerMovement.PlayerDirection.SOUTH_WEST:
                angle.y = -1;
                break;
        }

        switch (direction)
        {
            case PlayerMovement.PlayerDirection.EAST:
            case PlayerMovement.PlayerDirection.NORTH_EAST:
            case PlayerMovement.PlayerDirection.SOUTH_EAST:
                angle.x = 1;
                break;
            case PlayerMovement.PlayerDirection.WEST:
            case PlayerMovement.PlayerDirection.NORTH_WEST:
            case PlayerMovement.PlayerDirection.SOUTH_WEST:
                angle.x = -1;
                break;
        }

        body.velocity = angle * speed;
    }


    public void ThrowBall(PlayerMovement.PlayerDirection direction, Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        SetInitialVelocity(direction);
    }
}
