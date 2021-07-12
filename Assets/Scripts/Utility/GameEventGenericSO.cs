using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventGenericSO<T> : ScriptableObject
{

    public T Value { get; set; }

    protected List<GameEventListenerGeneric<T>> listeners = new List<GameEventListenerGeneric<T>>();


    public void AddListener(GameEventListenerGeneric<T> listener)
    {
        foreach (var obj in listeners)
        {
            if (obj == listener)
            {
                return;
            }
        }

        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListenerGeneric<T> listener)
    {
        while (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            if (listener != null)
            {
                listener.Response.Invoke(Value);
            }
        }
    }
}
