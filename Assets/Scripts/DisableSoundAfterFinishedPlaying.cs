using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSoundAfterFinishedPlaying : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    public AudioSource Source { get { return source; } }

    [SerializeField]
    SoundSettings settings;


    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        if (settings != null)
        {
            settings.RandomizeSettings(source);
        }

        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
