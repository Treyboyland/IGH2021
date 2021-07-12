using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreIncrease : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    int pointsPerSecond;

    float elapsed = 0;

    bool previousBallOwnedState = false;

    // Update is called once per frame
    void Update()
    {
        if (player.HasBall)
        {
            if (previousBallOwnedState != player.HasBall)
            {
                player.Score += pointsPerSecond;
                previousBallOwnedState = player.HasBall;
            }
            elapsed += Time.deltaTime;
            if (elapsed > 1)
            {
                player.Score += (int)elapsed;
                elapsed -= (int)elapsed;
            }
        }
        else
        {
            elapsed = 0;
            previousBallOwnedState = player.HasBall;
        }
    }
}
