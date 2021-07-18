using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlowController : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    GameObject glow;

    // Update is called once per frame
    void Update()
    {
        if (player.HasBall != glow.activeInHierarchy)
        {
            glow.gameObject.SetActive(player.HasBall);
        }
    }
}
