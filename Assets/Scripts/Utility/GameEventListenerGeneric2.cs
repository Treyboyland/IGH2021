using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerGeneric2<T, U> : MonoBehaviour
{
    [SerializeField]
    protected GameEventGenericSO2<T, U> eventSO;

    public UnityEvent<T, U> Response;

    protected void OnEnable()
    {
        eventSO.AddListener(this);
    }

    protected void OnDisable()
    {
        eventSO.RemoveListener(this);
    }
}
