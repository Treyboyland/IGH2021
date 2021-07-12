using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    [Tooltip("")]
    [SerializeField]
    bool isSinglePickup;

    public UnityEvent<Player> OnPlayerPickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            OnPlayerPickup.Invoke(player);
            if (isSinglePickup)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
