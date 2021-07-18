using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadAndLoopMusic : MonoBehaviour
{
    [SerializeField]
    AudioSource sourceStart;

    [SerializeField]
    AudioSource sourceLoop;

    [SerializeField]
    AudioClip start;

    [SerializeField]
    AudioClip loop;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenSwap());
    }

    IEnumerator WaitThenSwap()
    {
        // sourceStart.loop = false;
        // sourceStart.clip = start;
        // sourceStart.Play();
        // yield return new WaitForSecondsRealtime(start.length);
        // sourceStart.clip = loop;
        // sourceStart.loop = true;
        // sourceStart.Play();
        sourceStart.Play();
        yield return new WaitForSecondsRealtime(start.length);
        sourceLoop.Play();
    }
}
