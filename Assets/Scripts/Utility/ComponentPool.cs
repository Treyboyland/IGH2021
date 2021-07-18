using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    protected T objectPrefab;

    [SerializeField]
    protected int numToSpawn;

    [SerializeField]
    protected bool canGrow = true;

    protected List<T> pool = new List<T>();

    /// <summary>
    /// WARNING: Please don't modify this list
    /// </summary>
    /// <value></value>
    public List<T> PoolObjects { get { return pool; } }

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

    public int GetNumActive()
    {
        int count = 0;
        foreach (var obj in pool)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                count++;
            }
        }

        return count;
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

        return canGrow ? CreateObject() : null;
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
