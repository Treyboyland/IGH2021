using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticleAfterPlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }


    IEnumerator WaitThenDisable()
    {
        while (particle.isPlaying || particle.particleCount != 0)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
