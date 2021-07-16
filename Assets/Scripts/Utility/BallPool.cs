using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : ComponentPool<Ball>
{

    static BallPool _instance;

    public static BallPool Pool { get { return _instance; } }
    protected override void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        base.Awake();
    }
}
