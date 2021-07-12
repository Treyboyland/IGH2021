using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerGeneric<T> : MonoBehaviour
{
    [SerializeField]
    protected GameEventGenericSO<T> eventSO;

    public UnityEvent<T> Response;

    protected void OnEnable()
    {
        eventSO.AddListener(this);
    }

    protected void OnDisable()
    {
        eventSO.RemoveListener(this);
    }
}
