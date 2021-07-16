using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField]
    ComponentPool<MovingBall> pool;

    public void SpawnBall(PlayerMovement.PlayerDirection direction, Player player)
    {
        var ball = pool.GetObject();
        ball.ThrowBall(direction, player);
    }
}
