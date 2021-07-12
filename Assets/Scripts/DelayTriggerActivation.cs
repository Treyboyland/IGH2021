using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTriggerActivation : MonoBehaviour
{
    [SerializeField]
    Collider2D colliderToDisable;

    [SerializeField]
    float secondsToWait;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DisableThenEnable());
        }
    }


    IEnumerator DisableThenEnable()
    {
        colliderToDisable.enabled = false;
        yield return new WaitForSeconds(secondsToWait);
        colliderToDisable.enabled = true;
    }
}
