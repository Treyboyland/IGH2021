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

    [SerializeField]
    Vector4 topBoxDimensions;

    [SerializeField]
    Vector4 middleBoxDimensions;

    [SerializeField]
    Vector4 bottomBoxDimensions;

    [SerializeField]
    float platformWidth;

    public float SpawnsPerMinute { get { return spawnsPerMinute; } set { spawnsPerMinute = value; } }

    List<Vector3> possibleSpawns = new List<Vector3>();

    float spawnValue = 0;



    // Start is called before the first frame update
    void Start()
    {
        int num = UnityEngine.Random.Range(numInitial.x, numInitial.y);
        CalculateSpawns();
        //Debug.LogWarning("Num to spawn: " + num);
        StartCoroutine(SpawnBatch(num));
    }

    void CalculateSpawns()
    {
        possibleSpawns.AddRange(CalculateSpawns(topBoxDimensions));
        possibleSpawns.AddRange(CalculateSpawns(middleBoxDimensions));
        possibleSpawns.AddRange(CalculateSpawns(bottomBoxDimensions));
        var sb = new System.Text.StringBuilder();
        foreach (var position in possibleSpawns)
        {
            sb.Append(position + " ");
        }
        //Debug.LogWarning(sb.ToString());
        possibleSpawns.Shuffle();
    }

    List<Vector3> CalculateSpawns(Vector4 range)
    {
        float minX, maxX, minY, maxY;
        minX = range.x;
        maxX = range.y;
        minY = range.z;
        maxY = range.w;
        List<Vector3> toreturn = new List<Vector3>();
        //Add midpoint and then branch out;
        Vector3 midpoint = new Vector3(minX + (maxX - minX) / 2, minY + (maxY - minY) / 2);
        //Debug.LogWarning("Midpoint: " + midpoint);
        toreturn.Add(midpoint);

        //Disgusting calculation

        for (float x = midpoint.x; x <= maxX; x += platformWidth)
        {
            for (float y = midpoint.y; y <= maxY; y += platformWidth)
            {
                if (x == midpoint.x && y == midpoint.y)
                {
                    continue;
                }
                toreturn.Add(new Vector3(x, y));
            }
            for (float y = midpoint.y - platformWidth; y >= minY; y -= platformWidth)
            {
                if (x == midpoint.x && y == midpoint.y)
                {
                    continue;
                }
                toreturn.Add(new Vector3(x, y));
            }
        }

        for (float x = midpoint.x - platformWidth; x >= minX; x -= platformWidth)
        {
            for (float y = midpoint.y; y <= maxY; y += platformWidth)
            {
                if (x == midpoint.x && y == midpoint.y)
                {
                    continue;
                }
                toreturn.Add(new Vector3(x, y));
            }
            for (float y = midpoint.y - platformWidth; y >= minY; y -= platformWidth)
            {
                if (x == midpoint.x && y == midpoint.y)
                {
                    continue;
                }
                toreturn.Add(new Vector3(x, y));
            }
        }

        return toreturn;
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
        if (possibleSpawns.Count == 0)
        {
            return;
        }

        var position = possibleSpawns[possibleSpawns.Count - 1];
        possibleSpawns.RemoveAt(possibleSpawns.Count - 1); //More efficient than doing 0 index

        // var x = UnityEngine.Random.Range(spawnPositionRange.x, spawnPositionRange.y);
        // var y = UnityEngine.Random.Range(spawnPositionRange.z, spawnPositionRange.w);
        // Vector3 position = new Vector3(x, y, 0);
        var platform = pool.GetObject();
        platform.transform.SetParent(transform);
        platform.transform.localPosition = position;
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
