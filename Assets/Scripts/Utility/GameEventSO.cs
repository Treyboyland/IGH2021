using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/Null Event", order = 0)]
public class GameEventSO : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();


    public void AddListener(GameEventListener listener)
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

    public void RemoveListener(GameEventListener listener)
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
                listener.Response.Invoke();
            }
        }
    }
}
