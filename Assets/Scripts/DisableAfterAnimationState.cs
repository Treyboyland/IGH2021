using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterAnimationState : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    string stateName;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
