using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    GameEventSO eventSO;

    public UnityEvent Response;

    private void OnEnable()
    {
        eventSO.AddListener(this);
    }

    private void OnDisable()
    {
        eventSO.RemoveListener(this);
    }
}
