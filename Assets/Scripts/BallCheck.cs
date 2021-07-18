using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCheck : MonoBehaviour
{
    [SerializeField]
    float secondsToCheck;

    [SerializeField]
    BallPool ballPool;

    [SerializeField]
    PlatformPool platformPool;

    [SerializeField]
    int numToSpawn;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= secondsToCheck)
        {
            RunCheck();
        }
    }

    void RunCheck()
    {
        elapsed = 0;
        if (ballPool.GetNumActive() != 0)
        {
            return;
        }

        //Spawn Balls on random platforms
        List<SpawningPlatform> platforms = new List<SpawningPlatform>(platformPool.PoolObjects.Count);

        foreach (var platform in platformPool.PoolObjects)
        {
            if (platform.CurrentBall == null)
            {
                platforms.Add(platform);
            }
        }
        platforms.Shuffle();

        int num = numToSpawn >= platforms.Count ? platforms.Count : numToSpawn;

        for (int i = 0; i < num; i++)
        {
            platforms[i].SpawnBall();
        }

    }
}
