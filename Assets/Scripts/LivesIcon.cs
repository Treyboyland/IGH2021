using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesIcon : MonoBehaviour
{
    [SerializeField]
    int lifeId;

    [SerializeField]
    Animator icon;

    [SerializeField]
    string aliveState;

    [SerializeField]
    string gainTrigger;

    [SerializeField]
    string deathState;

    [SerializeField]
    string deathTrigger;

    public int LifeId { get { return lifeId; } set { lifeId = value; } }

    int currentLife = 0;

    public int CurrentLife { get { return currentLife; } set { currentLife = value; UpdateCounter(); } }

    private void Start()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        if (currentLife >= lifeId && !icon.GetCurrentAnimatorStateInfo(0).IsName(aliveState))
        {
            icon.SetTrigger(gainTrigger);
        }
        else if (currentLife < lifeId && !icon.GetCurrentAnimatorStateInfo(0).IsName(deathState))
        {
            icon.SetTrigger(deathTrigger);
        }
    }
}
