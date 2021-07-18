using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesHolder : MonoBehaviour
{
    [SerializeField]
    Player playerToTrack;

    [SerializeField]
    List<LivesIcon> icons;

    private void Awake()
    {
        SetIds();
        UpdateLives();
    }

    void SetIds()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].LifeId = i + 1;
        }
    }

    public void UpdateLives()
    {
        foreach (var life in icons)
        {
            life.CurrentLife = playerToTrack.Lives;
        }
    }
}
