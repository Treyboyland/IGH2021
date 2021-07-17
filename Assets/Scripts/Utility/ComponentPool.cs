using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    protected T objectPrefab;

    [SerializeField]
    protected int numToSpawn;

    protected List<T> pool = new List<T>();

    protected virtual void Awake()
    {
        Initialize();
    }


    protected void Initialize()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            CreateObject();
        }
    }

    protected T CreateObject()
    {
        var obj = Instantiate(objectPrefab, transform);
        obj.gameObject.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public T GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public void GetAndActivateObject()
    {
        var obj = GetObject();
        obj.gameObject.SetActive(true);
    }

    public void GetAndActivateObject(Vector3 position)
    {
        var obj = GetObject();
        obj.transform.position = position;
        obj.gameObject.SetActive(true);
    }

    public void DisableAll()
    {
        foreach (var obj in pool)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
