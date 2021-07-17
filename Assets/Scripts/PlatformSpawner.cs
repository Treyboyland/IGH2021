using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    Vector4 spawnPositionRange;

    [SerializeField]
    Vector2Int numInitial;

    [SerializeField]
    Vector2Int numSpawnedRange;

    [SerializeField]
    float spawnsPerMinute;

    [SerializeField]
    PlatformPool pool;

    public float SpawnsPerMinute { get { return spawnsPerMinute; } set { spawnsPerMinute = value; } }


    float spawnValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        int num = UnityEngine.Random.Range(numInitial.x, numInitial.y);
        Debug.LogWarning("Num to spawn: " + num);
        StartCoroutine(SpawnBatch(num));
    }

    // Update is called once per frame
    void Update()
    {
        spawnValue += spawnsPerMinute * Time.deltaTime;
        if (spawnValue > 60)
        {
            spawnValue -= 60;
            int num = UnityEngine.Random.Range(numSpawnedRange.x, numSpawnedRange.y);
            StartCoroutine(SpawnBatch(num));
        }
    }

    void SpawnPlatform()
    {
        var x = UnityEngine.Random.Range(spawnPositionRange.x, spawnPositionRange.y);
        var y = UnityEngine.Random.Range(spawnPositionRange.z, spawnPositionRange.w);
        Vector3 position = new Vector3(x, y, 0);
        var platform = pool.GetObject();
        platform.transform.position = position;
        platform.gameObject.SetActive(true);
    }
    IEnumerator SpawnBatch(int value)
    {
        for (int i = 0; i < value; i++)
        {
            SpawnPlatform();
            yield return null;
        }
    }
}
