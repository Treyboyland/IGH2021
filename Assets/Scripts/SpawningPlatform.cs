using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPlatform : MonoBehaviour
{
    [SerializeField]
    Vector2 spawnTimes;

    [SerializeField]
    Vector3 offset;

    float elapsed = 0;

    float currentSpawnTime;

    Ball currentBall;

    private void Update()
    {
        if (currentBall != null && !currentBall.gameObject.activeInHierarchy)
        {
            currentBall = null;
        }

        elapsed = currentBall == null ? elapsed + Time.deltaTime : elapsed;
        if (currentBall == null && elapsed >= currentSpawnTime)
        {
            SpawnBall();
        }
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        elapsed = 0;

        var ball = BallPool.Pool.GetObject();
        ball.transform.position = transform.position + offset;
        ball.gameObject.SetActive(true);
        currentBall = ball;

        currentSpawnTime = Random.Range(spawnTimes.x, spawnTimes.y);
    }
}
