using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPlatform : MonoBehaviour
{
    [SerializeField]
    Vector2 spawnTimes;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Vector3 endScale;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float spawnProbability;

    public Vector3 EndScale { get { return endScale; } }

    float elapsed = 0;

    float currentSpawnTime;

    Ball currentBall;

    private void Update()
    {
        DisableUsedBall();

        elapsed = currentBall == null ? elapsed + Time.deltaTime : elapsed;
        if (currentBall == null && elapsed >= currentSpawnTime)
        {
            SpawnBall();
        }
    }

    void DisableUsedBall()
    {
        if (currentBall != null && !currentBall.gameObject.activeInHierarchy)
        {
            currentBall = null;
        }
    }

    private void OnEnable()
    {
        DisableUsedBall();
        var probability = UnityEngine.Random.Range(0.0f, 1.0f);
        currentSpawnTime = Random.Range(spawnTimes.x, spawnTimes.y);
        if (gameObject.activeInHierarchy && probability < spawnProbability)
        {
            SpawnBall();
        }
    }

    private void OnDisable()
    {
        if (currentBall != null && currentBall.gameObject.activeInHierarchy)
        {
            currentBall.gameObject.SetActive(false);
            DisableUsedBall();
        }
    }

    void SpawnBall()
    {
        elapsed = 0;

        var ball = BallPool.Pool.GetObject();
        ball.transform.position = transform.position + transform.up * offset.y;
        ball.gameObject.SetActive(true);
        currentBall = ball;

        currentSpawnTime = Random.Range(spawnTimes.x, spawnTimes.y);
    }
}
