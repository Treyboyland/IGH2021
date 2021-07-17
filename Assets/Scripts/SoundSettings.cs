using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundSettings", menuName = "Sound/Sound Settings")]
public class SoundSettings : ScriptableObject
{
    [SerializeField]
    Vector2 pitchRange;

    [SerializeField]
    Vector2 volumeRange;

    [SerializeField]
    List<AudioClip> clips;


    public void RandomizeSettings(AudioSource source)
    {
        int index = UnityEngine.Random.Range(0, clips.Count);
        var clip = clips[index];
        float pitch = UnityEngine.Random.Range(pitchRange.x, pitchRange.y);
        float volume = UnityEngine.Random.Range(volumeRange.x, volumeRange.y);

        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
    }
}
