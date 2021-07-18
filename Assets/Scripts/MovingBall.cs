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
    Vector3Event onDestroyedLocation;

    [SerializeField]
    int maxBounces;

    int numBounces;

    Player launchedPlayer;

    /// <summary>
    /// Player that threw the ball
    /// </summary>
    /// <value></value>
    public Player LaunchedPlayer { get { return launchedPlayer; } }

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

        body.velocity = (angle.normalized * speed) + launchedPlayer.Body.velocity;
    }


    public void ThrowBall(PlayerMovement.PlayerDirection direction, Player player)
    {
        launchedPlayer = player;
        transform.position = player.transform.position;
        gameObject.SetActive(true);
        SetInitialVelocity(direction);
    }

    private void OnEnable()
    {
        numBounces = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null && player != launchedPlayer)
        {
            //Damage other player
            //Debug.LogWarning("Hit");
            player.DamagePlayer();
            DestroyBall();
        }
    }

    public void DestroyBall()
    {
        onDestroyedLocation.Value = transform.position;
        onDestroyedLocation.Invoke();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherBall = other.gameObject.GetComponent<MovingBall>();
        var wall = other.gameObject.GetComponent<Wall>();
        var playerBase = other.gameObject.GetComponent<PlayerBase>();
        if (wall != null)
        {
            numBounces++;
            if (numBounces > maxBounces)
            {
                DestroyBall();
            }
        }
        else if (otherBall != null && launchedPlayer != otherBall.LaunchedPlayer)
        {
            otherBall.DestroyBall();
            DestroyBall();
        }
    }
}
