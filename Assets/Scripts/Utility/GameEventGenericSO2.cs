using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventGenericSO2<T, U> : ScriptableObject
{

    public T Value1 { get; set; }

    public U Value2 { get; set; }

    protected List<GameEventListenerGeneric2<T, U>> listeners = new List<GameEventListenerGeneric2<T, U>>();


    public void AddListener(GameEventListenerGeneric2<T, U> listener)
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

    public void RemoveListener(GameEventListenerGeneric2<T, U> listener)
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
                listener.Response.Invoke(Value1, Value2);
            }
        }
    }
}
